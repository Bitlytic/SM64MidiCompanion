using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SM64MidiCompanion.Classes;
using SM64MidiCompanion.Components;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Newtonsoft.Json;

namespace SM64MidiCompanion
{
    public partial class Form1 : Form
    {
        MidiFile inputFile, outputFile;
        String seq64Command = "seq64_console.exe --abi=sm64 --in=.\\bin\\processed.mid --out={0}";
        private static SoundBank loadedSoundBank;

        private string openMidiDirectory = @"../", outputM64Directory = "@../", soundBankDirectory = "@../";

        public static SoundBank LoadedSoundBank { get => loadedSoundBank; set => loadedSoundBank = value; }

        public Form1()
        {
            InitializeComponent();
            saveErrorLabel.Text = "";

            if (inputFile == null)
            {
                refreshMidiButton.Visible = false;

            }
        }

        private void midiInputTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void openMidiButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = openMidiDirectory,
                Title = "Open Midi",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "mid",
                Filter = "Midi Files (*.mid;*.midi)|*.mid;*.midi",
                FilterIndex = 2
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                midiInputTextBox.Text = openFileDialog.FileName;
                openMidiDirectory = Path.GetDirectoryName(openFileDialog.FileName);
                LoadMidi(midiInputTextBox.Text);
            }
        }

        private void saveM64SelectButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "M64 Files (*.m64)|*.m64";
            saveFileDialog.Title = "Output Converted M64";
            saveFileDialog.InitialDirectory = outputM64Directory;
            saveFileDialog.RestoreDirectory = false;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!String.IsNullOrWhiteSpace(saveFileDialog.FileName))
                {
                    outputM64TextBox.Text = saveFileDialog.FileName;
                    outputM64Directory = Path.GetDirectoryName(saveFileDialog.FileName);
                }
            }
        }

        public void LoadMidi(String filename)
        {
            inputFile = MidiFile.Read(filename);

            List<TrackChunk> tracks = inputFile.Chunks.OfType<TrackChunk>().ToList();

            List<TrackInfo> trackInfos = new List<TrackInfo>();

            for (int i = 0; i < tracks.Count; i++)
            {
                TrackChunk track = tracks[i];
                trackInfos.Add(new TrackInfo(track));
            }

            trackNameListView.Tracks = trackInfos;
            refreshMidiButton.Visible = true;
        }

        public void LoadSoundBank(String filename)
        {
            StreamReader r = new StreamReader(filename);

            string json = r.ReadToEnd();
            loadedSoundBank = JsonConvert.DeserializeObject<SoundBank>(json);
            loadedSoundBank.FilterInstruments();
        }

        private void saveM64Button_Click(object sender, EventArgs e)
        {
            // Preprocess and deny if it fails validation (Enabled tracks don't have an instrument, output file isn't selected, midi isn't loaded, etc.)
            saveErrorLabel.Text = "";
            int enabledTrackCount = 0;
            bool valid = true;
            foreach (TrackInfo info in trackNameListView.Tracks)
            {
                if (!info.enabled)
                {
                    continue;
                }

                enabledTrackCount++;

                if (info.instrumentId < 0)
                {
                    valid = false;
                    saveErrorLabel.Text = "All enabled tracks must have\nan instrument.";
                    break;
                }

            }

            if (!valid)
            {
                return;
            }


            if (inputFile == null)
            {
                saveErrorLabel.Text = "No midi is currently loaded.";
                return;
            }

            if (trackNameListView.Tracks.Count <= 0 || enabledTrackCount <= 0)
            {
                saveErrorLabel.Text = "No tracks to export.";
                return;
            }

            if (String.IsNullOrWhiteSpace(outputM64TextBox.Text))
            {
                saveErrorLabel.Text = "Output M64 file must be\nselected.";
                return;
            }

            if (!File.Exists("./seq64_console.exe"))
            {
                saveErrorLabel.Text = "seq64_console.exe not found.\nThis should be in the same folder.";
                return;
            }

            SaveMidi(outputM64TextBox.Text);
        }

        private void refreshMidiButton_Click(object sender, EventArgs e)
        {
            if (inputFile == null)
            {
                return;
            }

            if (!File.Exists(midiInputTextBox.Text))
            {
                saveErrorLabel.Text = "Midi file does not exist.\nPerhaps it was moved?";
                return;
            }

            MidiFile midiFile = MidiFile.Read(midiInputTextBox.Text);

            List<String> trackNames = new List<string>();
            List<TrackChunk> tracks = midiFile.Chunks.OfType<TrackChunk>().ToList();

            bool newTracks = false;
            foreach (TrackChunk track in tracks)
            {
                bool exists = false;
                string name = "Unnamed Track";
                var trackNameEvents = track.Events.OfType<SequenceTrackNameEvent>();
                if (trackNameEvents != null && trackNameEvents.Count() > 0)
                {
                    name = track.Events.OfType<SequenceTrackNameEvent>().First().Text;
                }

                foreach (TrackInfo info in trackNameListView.Tracks)
                {
                    if (name.Equals(info.name))
                    {
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                {
                    newTracks = true;
                    break;
                }
            }

            if (newTracks || tracks.Count != trackNameListView.Tracks.Count)
            {
                if (DialogResult.OK == MessageBox.Show(
                    "Midi tracks have changed since originally imported.\nDo you wish to attempt auto importing?\n" +
                    "Tracks will attempt to be merged, but may introduce unintended side effects.",
                    "Reimport Alert",
                    MessageBoxButtons.OKCancel))
                {
                    MergeTracks(tracks);
                    inputFile = midiFile;
                }
            }
            else
            {
                inputFile = midiFile;
            }

        }

        private void autoAssignChannelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("This will auto assign each track to their own channel, and will overwrite any channel editing you may have done." +
                "\n\nDo you wish to proceed?", "Auto Assign Channels", MessageBoxButtons.OKCancel))
            {
                int i = 0;
                foreach (var track in trackNameListView.Tracks)
                {
                    if (track.enabled)
                    {
                        track.channel = i;
                        i++;
                    }
                }
                trackNameListView.LoadMidiItems();
            }
        }


        private void MergeTracks(List<TrackChunk> newTracks)
        {
            List<TrackInfo> tracks = trackNameListView.Tracks;
            List<TrackInfo> newTrackInfos = new List<TrackInfo>();

            foreach (var track in newTracks)
            {
                TrackInfo newTrackInfo = new TrackInfo(track);
                foreach (var existingTrackInfo in tracks)
                {
                    if (existingTrackInfo.name == newTrackInfo.name)
                    {
                        existingTrackInfo.Copy(newTrackInfo);
                        break;
                    }
                }

                newTrackInfos.Add(newTrackInfo);
            }

            trackNameListView.Tracks = newTrackInfos;
        }

        private void soundBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = soundBankDirectory,
                Title = "Load Decomp Sound Bank",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "json",
                Filter = "JSON Files (*.json)|*.json",
                FilterIndex = 2
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                soundBankDirectory = Path.GetDirectoryName(openFileDialog.FileName);
                LoadSoundBank(openFileDialog.FileName);
            }
        }

        public void SaveMidi(String filename)
        {
            List<TrackChunk> tracks = inputFile.Chunks.OfType<TrackChunk>().ToList();

            List<TrackChunk> outputTracks = new List<TrackChunk>();

            List<TrackInfo> trackInfos = trackNameListView.Tracks;

            for (int i = 0; i < tracks.Count; i++)
            {
                TrackInfo trackInfo = trackInfos[i];

                if (!trackInfo.enabled)
                {
                    continue;
                }

                // Create new Track
                TrackChunk newTrack = new TrackChunk();

                // Add Name, Program Change, etc. manually
                newTrack.Events.Add(new SequenceTrackNameEvent(trackInfo.name));
                ProgramChangeEvent programChangeEvent = new ProgramChangeEvent();
                programChangeEvent.Channel = (FourBitNumber)trackInfo.channel;
                programChangeEvent.ProgramNumber = (SevenBitNumber)trackInfo.instrumentId;
                newTrack.Events.Add(programChangeEvent);

                // Then, add all messages from original track except the ones we personally added
                foreach (MidiEvent e in tracks[i].Events)
                {
                    if (e is SequenceTrackNameEvent || e is ProgramChangeEvent)
                    {
                        continue;
                    }
                    else if (e is ControlChangeEvent controlChangeEvent)
                    {
                        if (controlChangeEvent.ControlNumber != ControlName.BankSelect.AsSevenBitNumber() ||
                            controlChangeEvent.ControlNumber != ControlName.LsbForBankSelect.AsSevenBitNumber())
                        {
                            newTrack.Events.Add(controlChangeEvent);
                        }
                        continue;
                    }
                    else if (e is PitchBendEvent pitchBendEvent)
                    {
                        newTrack.Events.Add(pitchBendEvent);
                        continue;
                    }
                    else if (e is MetaEvent metaEvent)
                    {
                        if (metaEvent.EventType == MidiEventType.Marker ||
                            metaEvent.EventType == MidiEventType.NormalSysEx ||
                            metaEvent.EventType == MidiEventType.SetTempo)
                        {
                            newTrack.Events.Add(metaEvent);
                        }
                        continue;
                    }
                    else if (e is ChannelEvent channelEvent)
                    {
                        channelEvent.Channel = (FourBitNumber)trackInfo.channel;

                        if (channelEvent is NoteEvent noteEvent)
                        {
                            noteEvent.NoteNumber = (SevenBitNumber)((int)noteEvent.NoteNumber + trackInfo.pitchShiftId);
                            newTrack.Events.Add(noteEvent);
                            continue;
                        }
                    }
                    else
                    {
                        newTrack.Events.Add(e);
                    }
                }

                // Put in outputTracks list
                outputTracks.Add(newTrack);
            }

            // Set output tracks
            outputFile = new MidiFile(outputTracks);
            outputFile.TimeDivision = inputFile.TimeDivision;

            foreach (MidiChunk chunk in inputFile.Chunks)
            {
                if (chunk is TrackChunk)
                {
                    continue;
                }
                outputFile.Chunks.Add(chunk);
            }

            // Save
            Directory.CreateDirectory("bin");
            try
            {
                outputFile.Write("./bin/processed.mid", true);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, "Unable to save file");
                return;
            }

            string cmd = String.Format(seq64Command, filename);
            Process process = new Process();

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "seq64_console.exe";
            startInfo.Arguments = "--abi=sm64 --in=bin\\processed.mid --out=" + filename;
            if (flStudioCheckbox.Checked)
            {
                startInfo.Arguments += " --flstudio=true";
            }
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardInput = false;
            process.StartInfo = startInfo;
            
            // Grab output, will probably use this to log so people can see what went wrong in the future
            process.Start();

            string output = process.StandardOutput.ReadToEnd();

            using (StreamWriter file = new StreamWriter("bin\\logs.txt"))
            {
                file.WriteLine(output);
            }

            process.WaitForExit();

            return;
        }
    }
}
