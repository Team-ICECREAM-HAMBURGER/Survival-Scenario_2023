using UnityEngine;
using UnityEngine.UI;

public class GameControlDictionary {
    public class Inventory : SerializableDictionary<GameControlType.Item, int> { }
    public class Status : SerializableDictionary<GameControlType.Status, float> { }
    public class StatusEffect : SerializableDictionary<GameControlType.StatusEffect, int> { }
    
    [System.Serializable] public class ItemTool : SerializableDictionary<GameControlType.Item, global::ItemTool> { }
    [System.Serializable] public class ItemMaterial : SerializableDictionary<GameControlType.Item, global::ItemMaterial> { }
    [System.Serializable] public class ItemFood : SerializableDictionary<GameControlType.Item, global::ItemFood> { }
    [System.Serializable] public class StatusGaugeSlider : SerializableDictionary<GameControlType.Status, Slider> { }
    [System.Serializable] public class StatusEffectText : SerializableDictionary<GameControlType.StatusEffect, GameObject> { }

    [System.Serializable] public class RequireItemsFire : SerializableDictionary<GameControlType.Item, int> { }
}