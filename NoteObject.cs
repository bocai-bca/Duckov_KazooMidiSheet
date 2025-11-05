using KazooMidiSheet.Config;
using UnityEngine;
using UnityEngine.UI;

namespace KazooMidiSheet
{
	public class NoteObject
	{
		public GameObject gameObject = new GameObject("KazooMidiSheetNote");
		public RectTransform? transform;
		public Image? image;
		public float pitch;
		public float startTime;
		public float endTime;
		public void Update()
		{
			if (transform == null)
			{
				return;
			}
			float delta = startTime - Time.time + KazooMidiSheet.timeWhenLoaded; //当前时间相对于该音符起始的时间差异
			float posX = (pitch + ConfigHolder.ConfigData.NoteObjPosXAddi) * ConfigHolder.ConfigData.NoteObjPosXMulti;
			float posY = Screen.height * delta / ConfigHolder.ConfigData.NoteFlowSeconds;
			//float posY = (Screen.height / 2f) - (Screen.height / ConfigHolder.ConfigData.NoteFlowSeconds * delta);
			transform.localPosition = new Vector3(posX, posY + ConfigHolder.ConfigData.NoteObjPosYAddi);
		}
		public NoteObject(Transform parent, Color newColor, float newPitch, Vector2 startAndEndTime)
		{
			transform = gameObject.AddComponent<RectTransform>();
			transform.SetParent(parent);
			transform.anchoredPosition = new Vector2(0f, -2f);
			image = gameObject.AddComponent<Image>();
			image.sprite = ModBehaviour.whiteSprite;
			image.color = newColor;
			pitch = newPitch;
			startTime = startAndEndTime.x;
			endTime = startAndEndTime.y;
			float durationSeconds = endTime - startTime;
			float noteLength = durationSeconds / ConfigHolder.ConfigData.NoteFlowSeconds;
			transform.localScale = new Vector3(0.1f, noteLength * ConfigHolder.ConfigData.NoteObjLengthMulti);
		}
	}
}