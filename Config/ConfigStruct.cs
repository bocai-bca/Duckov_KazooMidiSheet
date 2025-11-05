namespace KazooMidiSheet.Config
{
	public struct ConfigStruct
	{
		public float NoteFlowSeconds;
		public float HueOffsetPerTrack;
		public float NoteAlpha;
		public float NoteObjPosXAddi;
		public float NoteObjPosXMulti;
		public float NoteObjPosYAddi;
		public float NoteObjLengthMulti;
		public float SpeedMulti; //速度乘数，将作为除数作用于所有音符的时间点，不可为0
	}
}