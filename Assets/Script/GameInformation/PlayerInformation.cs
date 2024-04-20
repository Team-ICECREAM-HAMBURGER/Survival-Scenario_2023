using System;
using UnityEngine.Serialization;

[Serializable]
public class PlayerInformation {
    public string name = string.Empty;
    public GameControlDictionary.PlayerInventory inventory = new();
    public GameControlDictionary.PlayerStatus status = new();
    public GameControlDictionary.PlayerStatusEffect statusEffect = new();
}