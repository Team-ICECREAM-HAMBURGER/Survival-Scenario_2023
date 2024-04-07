using System;

[Serializable]
public class PlayerStatusDictionary : SerializableDictionary<GameTypeStatus, IPlayerStatus> { }