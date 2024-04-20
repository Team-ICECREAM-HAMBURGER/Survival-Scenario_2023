using System;

public class GameControlDictionary {
    public class Inventory : SerializableDictionary<string, int> { }
    public class Status : SerializableDictionary<GameControlType.Status, IPlayerStatus> { }
    public class StatusEffect : SerializableDictionary<GameControlType.StatusEffect, > { }
    
    // public class SpawnItem : SerializableDictionary<string, ItemSpawn> { }
    // public class CraftItem : SerializableDictionary<string, ItemCraft> { }
}