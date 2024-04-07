using System;

[Serializable]
public class PlayerStatusEffectDictionary : SerializableDictionary<GameTypeStatusEffect, IPlayerStatusEffect> { }