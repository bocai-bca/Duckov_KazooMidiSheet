# 安装

有两个方法，一个是用创意工坊，一个是从github获取后手动安装到游戏

## 创意工坊

链接：[https://steamcommunity.com/sharedfiles/filedetails/?id=3600381042](https://steamcommunity.com/sharedfiles/filedetails/?id=3600381042&tscn=1762532814)

物品名：`卡祖笛MIDI示谱器KazooMidiSheet`

本项目依赖[HarmonyLib](https://steamcommunity.com/sharedfiles/filedetails/?id=3589088839)，不要忘记订阅它。  
完成订阅后，到游戏里Mods菜单确保HarmonyLib排列在本mod上方，若HarmonyLib尚未勾选则先勾选HarmonyLib，然后勾选本mod即可启用。  

## 手动安装文件
(适用于无法使用创意工坊的非Steam玩家)  

> 若您具备技术知识可以直接从源代码编译(若您有编译疑问可发Issue)，然后遵照[DuckovModding示例](https://github.com/xvrsl/duckov_modding)来在本地创建mod文件夹和元数据。

首先获取本mod的发行版文件，您可在[Releases页面](https://github.com/bocai-bca/Duckov_KazooMidiSheet/releases)选择Latest版本下载。  
来到`Duckov_Data/Mods`文件夹，如果您那边不存在`Mods`文件夹，可以手动创建一个。  
将下载到的本mod解压到`Mods`文件夹中，保持本mod以套一层文件夹的形态存放在`Mods`文件夹中，最终形成以下树形结构：
```
Escape from Duckov
├─ Duckov.exe
├─ ...
└─ Duckov_Data
   ├─ ...
   └─ Mods
      ├─ KazooMidiSheet
      |  ├─ KazooMidiSheet.dll
      |  ├─ preview.png
      |  ├─ info.ini
      |  └─ description.txt
      └─ ...
```

本mod依赖于[Harmony](https://github.com/pardeike/Harmony) 2.4.1，您可使用任何您知道的方法为游戏打上Harmony。  

> ### 如果您不知道要怎么做  
> 到Harmony存储库的Releases中下载一个[2.4.1.0](https://github.com/pardeike/Harmony/releases/download/v2.4.1.0/Harmony-Fat.2.4.1.0.zip)，将其中的`net472`中的`0Harmony.dll`放到本mod的dll一起。  
> 这样做之后您可能需要留意一下是否有其他mod同样使用了自备的Harmony，可能会导致重复加载。  
> 或者您可以前往[HarmonyLib创意工坊物品](https://steamcommunity.com/sharedfiles/filedetails/?id=3589088839)去看看有没有谁提供给不能使用创意工坊的玩家什么方便省事的办法。    

之后，到游戏里勾选本mod即可。

## 完成安装并成功在游戏内勾选后

您可以前往[如何使用](how_to_use.md)篇了解怎样使用本mod了。