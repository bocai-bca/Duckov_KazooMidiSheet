using System;
using System.IO;
using System.Collections.Generic;
using KazooMidiSheet.Config;
using MidiParser;
using UnityEngine;
using Object = UnityEngine.Object;

namespace KazooMidiSheet
{
	public static class KazooMidiSheet
	{
		public const string MOD_NAME = "KazooMidiSheet";
		public static string MidiFilePath
		{
			get
			{
				return Path.Combine(Application.streamingAssetsPath, "KazooMidiSheet", "load.mid");
			}
		}
		public static bool wasTriggedLoadingOnThisKazooHolding = false;
		public static bool wasMidiLoaded;
		public static float timeWhenLoaded;
		public static RectTransform? uiParent;
		public static MidiFile? midiFile;
		public static int BPM;
		public static float ticksPerSecond;
		public static List<NoteObject> noteObjects = new List<NoteObject>();
		public static bool LoadMidi()
		{
			Logger.Log(Logger.LogLevel.Info, "读入配置文件");
			ConfigHolder.ReadFromFile();
			Logger.Log(Logger.LogLevel.Info, "开始加载midi");
			Logger.Log(Logger.LogLevel.Info, "将应用速度乘数" + ConfigHolder.ConfigData.SpeedMulti);
			wasMidiLoaded = false;
			if (!File.Exists(MidiFilePath))
			{
				Logger.Log(Logger.LogLevel.Warning, "未能加载midi，不存在load.mid文件");
				return false;
			}
			try
			{
				midiFile = new MidiFile(MidiFilePath);
			}
			catch (Exception e)
			{
				Logger.Log(Logger.LogLevel.Error, "未能加载midi，解析器出错，异常：" + e.Message);
				throw;
			}
			if (!(midiFile.Format == 0 ||  midiFile.Format == 1))
			{
				Logger.Log(Logger.LogLevel.Error, "未能加载midi，只支持单、多轨道格式(0、1)，当前：" + midiFile.Format);
				return false;
			}
			float ticksPerBeat = midiFile.TicksPerQuarterNote;
			// 音符缓存，键=音高，值=音符开始事件
			for (int i = 0; i < midiFile.TracksCount; i++)
			{
				Logger.Log(Logger.LogLevel.Info, "开始解析轨道：" + i);
				Dictionary<byte, MidiEvent> eventCache = new Dictionary<byte, MidiEvent>();
				MidiTrack this_track = midiFile.Tracks[i];
				foreach (MidiEvent midiEvent in this_track.MidiEvents)
				{
					switch (midiEvent.MidiEventType) //匹配当前MIDI事件的类型
					{
						case MidiEventType.MetaEvent: //如果类型为元数据
							if (midiEvent.Arg1 == (int)MetaEventType.Tempo) //如果元数据类型为Tempo
							{
								BPM = midiEvent.Arg2; //记录BPM
							}
							break;
						case MidiEventType.NoteOn: //如果类型为音符开始
							eventCache.TryAdd(midiEvent.Arg2, midiEvent);
							break;
						case MidiEventType.NoteOff: //如果类型为音符结束
							if (eventCache.ContainsKey(midiEvent.Arg2))
							{
								//Logger.Log(Logger.LogLevel.Info, "确认到成对音符事件，音符值=" + midiEvent.Arg2 + "，起点=" + eventCache[midiEvent.Arg2].Time + "，长度=" + (midiEvent.Time - eventCache[midiEvent.Arg2].Time));
								Color color = Color.HSVToRGB(i * ConfigHolder.ConfigData.HueOffsetPerTrack % 1.0f, 0.75f, 1.0f);
								color.a = ConfigHolder.ConfigData.NoteAlpha;
								AddNewNote(color, midiEvent.Arg2, new Vector2(eventCache[midiEvent.Arg2].Time / ticksPerSecond / ConfigHolder.ConfigData.SpeedMulti, midiEvent.Time / ticksPerSecond / ConfigHolder.ConfigData.SpeedMulti));
								eventCache.Remove(midiEvent.Arg2);
							}
							break;
					}
				}
				if (eventCache.Count != 0)
				{
					Logger.Log(Logger.LogLevel.Error, "轨道未闭合所有音符开始事件，轨道索引：" + i);
				}
			}
			timeWhenLoaded = Time.time;
			ticksPerSecond = ticksPerBeat * BPM / 60f;
			Logger.Log(Logger.LogLevel.Info, "已加载midi，BPM：" + BPM + "，TPS：" + ticksPerSecond + "，轨道数：" + midiFile.Tracks.Length + "，总音符数：" + noteObjects.Count);
			wasMidiLoaded = true;
			return true;
		}
		public static void AddNewNote(Color noteColor, float notePitch, Vector2 startAndEndTime)
		{
			if (uiParent == null)
			{
				return;
			}
			noteObjects.Add(new NoteObject(uiParent, noteColor, notePitch, startAndEndTime));
		}
		public static void CreateUIParent()
		{
			HUDManager? hudManager = Object.FindObjectOfType<HUDManager>();
			if (hudManager != null)
			{
				GameObject uiParentGameObject = new GameObject("KazooMidiSheetUI");
				uiParent = uiParentGameObject.AddComponent<RectTransform>();
				uiParent.SetParent(hudManager.transform);
				uiParent.localPosition = Vector3.zero;
			}
		}
	}
}