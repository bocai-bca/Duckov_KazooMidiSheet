using System;
using UnityEngine;
using System.IO;

namespace KazooMidiSheet.Config
{
	public static class ConfigHolder
	{
		public static string ConfigFilePath
		{
			get
			{
				return Path.Combine(Application.streamingAssetsPath, "KazooMidiSheet", "config.json");
			}
		}
		
		public static ConfigStruct ConfigData = MakeDefault();

		public static bool ReadFromFile()
		{
			if (!File.Exists(ConfigFilePath))
			{
				Logger.Log(Logger.LogLevel.Warning, "配置文件不存在");
				return false;
			}
			string configContent = File.ReadAllText(ConfigFilePath);
			if (string.IsNullOrEmpty(configContent))
			{
				Logger.Log(Logger.LogLevel.Error, "配置文件内容未空或读取错误");
				return false;
			}
			ConfigData = JsonUtility.FromJson<ConfigStruct>(configContent);
			return true;
		}

		public static bool SaveToFile()
		{
			try
			{
				string json = JsonUtility.ToJson(ConfigData, true);
				Directory.CreateDirectory(Path.GetDirectoryName(ConfigFilePath)!);
				File.WriteAllText(ConfigFilePath, json);
			}
			catch (Exception)
			{
				Logger.Log(Logger.LogLevel.Error, "保存配置文件时发生问题");
				throw;
			}
			return true;
		}
		
		public static ConfigStruct MakeDefault()
		{
			ConfigStruct result = new ConfigStruct
			{
				NoteFlowSeconds = 3.0f,
				HueOffsetPerTrack = 0.23f,
				NoteAlpha =	0.75f,
				NoteObjPosXAddi = -63f,
				NoteObjPosXMulti = 38.4f,
				NoteObjPosYAddi = 128f,
				NoteObjLengthMulti = 3f,
				SpeedMulti = 1f,
			};
			return result;
		}
	}
}