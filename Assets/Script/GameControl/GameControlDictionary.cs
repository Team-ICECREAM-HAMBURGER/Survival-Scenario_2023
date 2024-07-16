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
    
    [System.Serializable] public class GameRandomEvent : SerializableDictionary<GameControlType.RandomEvent, global::GameRandomEvent> { }
    
    [System.Serializable] public class PlayerStatus : SerializableDictionary<GameControlType.Status, global::PlayerStatus> { }
    [System.Serializable] public class PlayerStatusEffect : SerializableDictionary<GameControlType.StatusEffect, global::PlayerStatusEffect> { }
    [System.Serializable] public class PlayerBehaviour : SerializableDictionary<GameControlType.Behaviour, global::PlayerBehaviour> { }
    
    [System.Serializable] public class RequireItem : SerializableDictionary<GameControlType.Item, int> { }
    [System.Serializable] public class RequireStatus : SerializableDictionary<GameControlType.Status, float> { }
}