using System;
using UnityEngine.Serialization;

[Serializable]
public class PlayerInformation {
    public string name = "";
    public GameControlDictionary.Inventory inventory = new();
    public GameControlDictionary.Status status = new() {
        { GameControlType.Status.STAMINA, 100f },
        { GameControlType.Status.BODY_HEAT, 100f },
        { GameControlType.Status.HYDRATION, 100f },
        { GameControlType.Status.CALORIES, 100f }
    };
    public GameControlDictionary.StatusEffect statusEffect = new();
}