using UnityEngine;

public class ItemMedicine : Item {
    public override string ItemName { get; set; }
    public override int Count { get; set; }
    public override float Weight { get; set; }
    
    public override bool IsAcquirable { get; } = false;
    public override itemType ItemType { get; } = itemType.MEDICINE;
    public override eventType EventType { get; } = eventType.NONE;


    public ItemMedicine(string itemName = "약품", int count = 0, float weight = 0f) {
        this.ItemName = itemName;
        this.Count = count;
        this.Weight = weight;
    }
}