using UnityEngine.UI;

public class GameControlDictionary {
    public class Inventory : SerializableDictionary<string, int> { }
    public class Status : SerializableDictionary<GameControlType.Status, float> { }
    public class StatusEffect : SerializableDictionary<GameControlType.StatusEffect, int> { }
    
    [System.Serializable] public class ItemTool : SerializableDictionary<GameControlType.Item, global::ItemTool> { }
    [System.Serializable] public class ItemMaterial : SerializableDictionary<GameControlType.Item, global::ItemMaterial> { }
    [System.Serializable] public class ItemFood : SerializableDictionary<GameControlType.Item, global::ItemFood> { }
    
    [System.Serializable] public class StatusGauge : SerializableDictionary<GameControlType.Status, Slider> { } 

}