using System;

public class GameControlDictionary {
    public class PlayerInventory : SerializableDictionary<string, int> { }
    public class PlayerStatus : SerializableDictionary<GameControlType.Status, IPlayerStatus> { }
    public class PlayerStatusEffect : SerializableDictionary<string, StatusEffect> { }
    
    // public class SpawnItem : SerializableDictionary<string, ItemSpawn> { }
    // public class CraftItem : SerializableDictionary<string, ItemCraft> { }

    //[Serializable] public class StatusEffects : SerializableDictionary<GameControlType.StatusEffect, StatusEffect> { }
}