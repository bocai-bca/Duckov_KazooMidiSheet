文档仍然在施工中🚧
  
# 简介

本项目是游戏《逃离鸭科夫》的模组。  
请在使用前详细阅读本篇文档。  
本文档的编写目的旨在尽力消除使用本项目时用户可能获得的任何疑惑，因此如果您发现文档没有提及您产生的疑问，或者文档的叙述令您难以理解，可提Issue指出文档中令您困惑的地方来帮助改善文档。  

### How to use

Load the mod in game.  
Go to the folder `Duckov_Data/StreamingAssets/KazooMidiSheet`.  
You should edit something in `config.json` to you needed, like play speed, X offset etc.  

# 早期测试版本，可能不稳定

当前本项目仍处于早期测试阶段，不适合在游戏中通常地游玩。   
您可能会遇到：  
- MIDI钢琴卷帘的播放速度与MIDI文件的BPM不匹配
- 音符的音高坐标不正确/不精确
- 音符的长度不正确/不精确
- 音符下落的触线时间不正确/不精确

# 使用手册

- [安装](installation.md)
- [如何使用](how_to_use.md)

# 使用的其他库

[midi-parser](https://github.com/davidluzgouveia/midi-parser) by [David Gouveia](https://github.com/davidluzgouveia). 一个不错的C#写的SMF \(Standard Midi File\)解析器
