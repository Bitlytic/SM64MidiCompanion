using Melanchall.DryWetMidi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM64MidiCompanion.Components
{
    class TrackInfo
    {
        public String name = "Unnamed Track";
        public bool enabled = true;
        public int instrumentId = -1;
        public int pitchShiftId = 0;
        public int channel = 0;

        public TrackInfo(TrackChunk chunk)
        {
            foreach (MidiEvent e in chunk.Events)
            {

                if (e is SequenceTrackNameEvent sequenceTrackNameEvent)
                {
                    name = sequenceTrackNameEvent.Text;
                }
                else if (e is ProgramChangeEvent programChangeEvent)
                {
                    // Accounts for the drum channel, as per the General MIDI standard
                    instrumentId = (programChangeEvent.Channel == 9) ? 127 : programChangeEvent.ProgramNumber;
                    channel = programChangeEvent.Channel;
                }
            }
        }

        public void Copy(TrackInfo newTrackInfo)
        {
            newTrackInfo.channel = this.channel;
            newTrackInfo.enabled = this.enabled;
            newTrackInfo.instrumentId = this.instrumentId;
            newTrackInfo.pitchShiftId = this.pitchShiftId;
            newTrackInfo.name = this.name;
        }
    }
}
