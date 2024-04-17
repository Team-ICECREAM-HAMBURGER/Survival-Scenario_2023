using System;

[Serializable]
public class PlayerInformation {
    public string name = string.Empty;
    public GameControlDictionary.Inventory inventory = new();
    public GameControlDictionary.Status status = new();
    public GameControlDictionary.StatusEffect statusEffect = new();
}