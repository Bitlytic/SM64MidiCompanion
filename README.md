# SM64MidiCompanion v0.1
This program is only compatible with Windows (I'm sorry Linux users)

## SEQ64
The releases of this software bundles in SEQ64, which is created by sauraen and can be found [here.](https://github.com/sauraen/seq64)

## What is This Tool?
Music making for sm64 typically requires editing the midi through Anvil Studio or Sekaiju, and this program aims to eliminate most of the manual midi editing 
and open up the ability to use programs like LMMS or FLStudio without having to clean up the midi yourself.

## How to Use
Currently, it is as easy as downloading the latest [release](https://github.com/Bitlytic/SM64MidiCompanion/releases) and unzipping. If you run `SM64MidiCompanion.exe`
you may need to reassure Windows the program is safe. 

## First Time Tutorial
1. Start by loading a .mid/.midi file through the `Midi Input File` field
2. Disable any tracks that you don't need
3. Double click instrument ID column of track to change (Decomp users get a special feature here)
4. Channels of tracks, only one instrument per channel is allowed in sm64
5. Select a .m64 output location (Will not save until you hit export)
6. Hit Export .m64 button
7. Done.

You should be able to build your rom and hear your music in game. If any of the instruments sound like they are higher or lower than they should be, 
check the below section

## Pitch Shifting
As you may have noticed, certain instruments in sm64 are either pitch shifted up or down. This can cause issues if, say, you want a C3 and it plays a C4.
Instead of needing to shift this manually through your DAW, simply put a value in the `Pitch Shift` column.

The amount shifted is in semitones, so -12 is down an octave and 12 is up an octave. This will not save over your original midi and will only be reflected in the
output .m64 file.

## Decomp Sound Bank Loading
Decomp users can load sound bank .json files into the program and pick from the list of instruments in that bank.

1. `File -> Load Sound Bank...`
2. Find sound bank in `sound/sound_banks`
3. Load the .json corresponding to your level (Example: Bob-Omb Battlefield's music uses bank 22.json)
4. Double click instrumentID column of a track
5. Open the drop down and select the instrument you want (This uses the .aiff file names)
6. That's it

## Hot Reload
If you have made midi changes and saved out from your DAW, you can click the refresh button next to the input to reload those changes into the program. All this does 
is pull your new changes into the program so you don't have to manually reimport everytime you change something in your composition.

If any tracks are added, removed, or renamed, the program will try its best to merge the changes to Pitch, Instrument, etc. to the new tracks.

## LMMS Specific Stuff
If you are using LMMS, here's a couple tips I have

`Edit -> Auto Assign Channels` will assign all enabled channels a separate ID, LMMS defaults all exported tracks to 0, which is stupid.

If there's a channel called "Kicker" disable it, LMMS for some reason always exports this track even if it doesn't exist and it screws with your sm64.


# Building
If, for some reason, you wish to build this, it was built using `Visual Studio 2019` and has dependences on these NuGet packages:

- [DryWetMidi](https://www.nuget.org/packages/Melanchall.DryWetMidi)
- [Newtonsoft Json](https://www.newtonsoft.com/json)

Additionally, `SEQ64` is not built nor included in the actual source, so you will need to download [SEQ64 v2.1.4](https://github.com/sauraen/seq64/releases/tag/2.1.4) 
and either place SEQ64 in the build folder, or place the build .exe and .dll files into the SEQ64 folder.
