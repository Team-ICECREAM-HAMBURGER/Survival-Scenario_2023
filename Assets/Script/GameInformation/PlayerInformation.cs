using System;

[Serializable]
public class PlayerInformation {
    public string name;
    public PlayerInventoryDictionary inventory;
    public PlayerStatusDictionary status;
    public PlayerStatusEffectDictionary statusEffect;

    
    public PlayerInformation() {
        this.name = String.Empty;
        this.inventory = new();
        this.status = new();
        this.statusEffect = new();
    }
}