using System;
using HarmonyLib;
using Object = UnityEngine.Object;

namespace KazooMidiSheet
{
	[HarmonyPatch(typeof(ItemAgent_Kazoo), "Update", new Type[0])]
	public class Patch_KazooUIUpdate
	{
		public static void Postfix(ItemAgent_Kazoo __instance)
		{
			if (!KazooMidiSheet.wasTriggedLoadingOnThisKazooHolding)
			{
				KazooMidiSheet.wasTriggedLoadingOnThisKazooHolding = true;
				if (KazooMidiSheet.uiParent == null)
				{
					KazooMidiSheet.CreateUIParent();
				}
				if (!KazooMidiSheet.LoadMidi())
				{
					return;
				}
			}
			if (!KazooMidiSheet.wasMidiLoaded)
			{
				return;
			}
			foreach (NoteObject noteObject in KazooMidiSheet.noteObjects)
			{
				noteObject.Update();
			}
		}
	}
}