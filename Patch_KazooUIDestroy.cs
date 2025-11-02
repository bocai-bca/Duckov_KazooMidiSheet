using System;
using HarmonyLib;
using Object = UnityEngine.Object;

namespace KazooMidiSheet
{
	[HarmonyPatch(typeof(ItemAgent_Kazoo), "OnDestroy", new Type[0])]
	public class Patch_KazooUIDestroy
	{
		// ReSharper disable once UnusedMember.Local
		private static void Postfix()
		{
			KazooMidiSheet.wasMidiLoaded = false;
			KazooMidiSheet.wasTriggedLoadingOnThisKazooHolding = false;
			foreach (NoteObject noteObject in KazooMidiSheet.noteObjects)
			{
				if (noteObject.gameObject != null)
				{
					Object.Destroy(noteObject.gameObject);
				}
			}
			KazooMidiSheet.noteObjects.Clear();
		}
	}
}