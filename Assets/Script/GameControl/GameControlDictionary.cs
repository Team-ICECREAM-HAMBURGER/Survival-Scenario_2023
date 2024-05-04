public class GameControlDictionary {
    public class Inventory : SerializableDictionary<string, int> { }
    public class Status : SerializableDictionary<GameControlType.Status, float> { }
    public class StatusEffect : SerializableDictionary<GameControlType.StatusEffect, int> { }

}