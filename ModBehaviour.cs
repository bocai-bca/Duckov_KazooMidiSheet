using HarmonyLib;
using KazooMidiSheet.Config;
using UnityEngine;

namespace KazooMidiSheet
{
	public class ModBehaviour : Duckov.Modding.ModBehaviour
	{
		public static Harmony harmony = new Harmony("KazooMidiSheet");
		public static Sprite whiteSprite = Sprite.Create(Texture2D.whiteTexture, new Rect(0f, 0f, 4f, 4f), new Vector2(2f, 0f));
		public void OnEnable()
		{
			ConfigHolder.ReadFromFile();
			ConfigHolder.SaveToFile();
			harmony.PatchAll();
		}
		public void OnDisable()
		{
			ConfigHolder.SaveToFile();
			harmony.UnpatchSelf();
		}
	}
}