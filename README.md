README is outdated, please waiting for update.
 
 # Intro

This is a mod for video game "Escape from Duckov".  
Please fully read this README before you use.  

### Installtion

Download a release or build one with source.  
Go to the folder `Duckov_Data/Mods` (you can create one if it doesn't exist).  
Follow this [guide](https://github.com/xvrsl/duckov_modding), make a mod folder and put the dll file inside.

### How to use

Load the mod in game.  
Go to the folder `Duckov_Data/StreamingAssets/KazooMidiSheet`.  
You should edit something in `config.json` to you needed, like play speed, X offset etc.  

# EarlyAccess Now, Working Unstable

This project is still during early access phase and isn't suitable to playing in game normally.  
You will encounter:  
- The running speed of Midi Roller isn't matched to the BPM of the midi the playing. (But you can fix it by set the speed multiplier manually)
- Notes' position of pitch aren't correct/precision. (But you can fix it by set the Xoffset or Xmultiplier manually)  
- Notes' length aren't correct/precision. (Well this is a trouble yet, but you still can try to fix it by set the LengthMultiplier manually)
- Notes' reach time aren't correct/precision. (Well this is a trouble yet too, but you also able to try to fix it by set the Yoffset manually)

# Other libraries used

[midi-parser](https://github.com/davidluzgouveia/midi-parser) by [David Gouveia](https://github.com/davidluzgouveia). A good SMF \(Standard Midi File\) parser in C#
