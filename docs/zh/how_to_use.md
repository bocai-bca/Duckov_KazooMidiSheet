# 如何使用

首先，您需要大致了解一下本mod的运作逻辑。  
本mod的所有行为分为两种：读取、播放。

**读取**。本mod会在此时执行和配置文件有关的操作，例如创建、读取、写入配置文件，以及在配置文件旁边搜寻`load.mid`来作为midi文件加载。  
**播放**。本mod会在播放操作开始的一瞬间立即在游戏内创建所有音符的GameObject，这基本上会让游戏卡顿一下，然后开始播放呈现为音符下落的钢琴卷帘。  

以下是触发**读取**和**播放**的时机：
- 本mod加载时(在Mods菜单被勾选/已被勾选时的游戏启动)，会触发**读取**
- 在游戏内掏出卡祖笛，会触发**读取**，然后触发**播放**。**播放**会一直持续到不再手持卡祖笛

在进行**读取**操作后，本mod的输入输出目录将被创建，该目录的位置为`Duckov_Data/StreamingAssets/KazooMidiSheet`，本文章将在后续将其简称为`{配置目录}`。

# 步骤式教学
本段落将以手把手一步步地形式教您使用本mod，如果您不喜欢这种风格，也可以跳转到下方的[文档式教学](#文档式教学)段落查看信息密度更高的参考文档风格。  

## 运行一次本mod
进入游戏，在Mods菜单中勾选本mod使其加载一次，这样它会生成配置目录和配置文件，我们之后要在那里放入midi文件以及修改配置参数。  

## 准备midi文件
本mod本身是不自带midi的，需要您自己准备好`.mid`文件。  
您可以从诸如[midishow](https://www.midishow.com/)、[bitmidi](https://bitmidi.com/)等网站寻找广袤的互联网上其他人上传的midi文件，以及您可以使用诸如[GarageBand](https://apps.apple.com/cn/app/garageband/id682658836)、[Logic Pro](https://apps.apple.com/cn/app/logic-pro/id634148309)、[FL Studio](https://www.image-line.com/)、[signal](https://signalmidi.app/)等软件/工具来编辑或创作midi文件。  
midi文件有三种格式，但本mod只支持两种，分别是单轨道格式和多轨道格式，不支持多曲目格式。  

## 放置midi文件
准备好midi之后，来到前文提到的`{配置目录}`文件夹中，你将能够在这里看到一个`config.json`，这个是配置文件。  
你可以将你弄好的midi文件先放在这里，作存储使用。  
要知道，本mod只会加载名称为`load.mid`的文件，所以您只需复制一个您放在这里的midi文件，然后重命名为`load.mid`即可。  

## 使用卡祖笛
放好`load.mid`之后，在游戏中手持卡祖笛即可，如果您感觉游戏卡顿了一下，那就说明对了，这个卡顿是本mod读取midi并创建谱面导致的。  

> 不要忘记，目前本mod仍属于施工/测试阶段，您可能会遇到各式各样的问题，您可以在GitHub上发Issue或者加入我的QQ群来寻求帮助。  
> 目前有一个显著的已知问题：每次进入游戏的首次掏出卡祖笛都不会显示谱面，重新掏一次即可

怎么吹笛就不用我教了吧。  

## 修改配置文件

配置文件向您提供了一部分参数的修改手段，配置文件是`{配置目录}/config.json`，您可通过任意文本编辑器/代码编辑器打开它，例如使用[Visual Studio Code](https://code.visualstudio.com/)、[Sublime Text](https://www.sublimetext.com/)，甚至是[记事本](https://apps.microsoft.com/detail/9msmlrh6lzf3)。  
手动修改配置文件可以帮助您实现修正不准的音高、播放速度、音符不透明度、调整时间偏移、音符长度、音符下落速度，具体参数请参考[配置文件结构](#配置文件结构)章节。  
修改并保存完配置文件后(一定不要忘记保存，不然就是改了个寂寞)，您可以重新掏出卡祖笛，在读取midi文件的同时本mod也会重新读一次配置文件。  

# 文档式教学

## 加载SMF(Standard Midi File)
本mod将在每次掏出卡祖笛时读取`{配置目录}/load.mid`，可以随时更换该文件。  
  
本mod不支持`format`为`2`(多曲目格式)的midi文件，只支持`0`(单轨道格式)和`1`(多轨道格式)。  
`format`被存储于midi文件的第9、10字节的位置。  
如果试图加载不支持的格式，本mod将在日志中报出错误。  
  
本mod只会反映midi事件中的"NoteOff"(`0x80`)和"NoteOn"(`0x90`)，以及"MetaEvent"(`0xFF`)中的"Tempo"(`0x51`)和"TimeSignature"(`0x58`)。  
即不支持如力度、音量、可变速度、弯音等数据，如果midi文件中存在这些数据，这些数据可能将根据其的特点表现为诸如被本mod无视等效果。  

## 配置文件结构
配置文件是`{配置目录}/config.json`，以下是配置文件内容：  
| 键 | 类型 | 默认值 | 描述 |
| --- | --- | --- | --- |
| NoteFlowSeconds | Float | 3.0 | 音符下落的时间，单位为秒(本参数相关功能正在施工中) |
| HueOffsetPerTrack | Float | 0.23 | 轨道之间的HSV色彩空间色相变化差距，值越大差距越大 |
| NoteAlpha | Float | 0.75 | 可填0-1，音符的不透明度，值越低越透明 |
| NoteObjPosXAddi | Float | -63.0 | 音符的水平位置偏移(正值向右)，执行偏移优先于执行缩放 |
| NoteObjPosXMulti | Float | 38.4 | 音符的水平位置缩放(数值越大音符间隔越大)，执行缩放在执行偏移之后 |
| NoteObjPosYAddi | Float | 128.0 | 音符的垂直位置偏移(正值向上，可通过设置更大的值来延迟音符的下落) |
| NoteObjLengthMulti | Float | 3.0 | 音符长度乘数(本参数相关功能正在施工中) |
| SpeedMulti | Float | 1.0 | 播放速度乘数，修饰音符的时间数据 |