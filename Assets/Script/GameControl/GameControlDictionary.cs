public class GameControlDictionary {
    public class Inventory : SerializableDictionary<string, int> { }
    public class Status : SerializableDictionary<GameControlType.Status, IPlayerStatus> { }
    public class StatusEffect : SerializableDictionary<string, int> { }

}