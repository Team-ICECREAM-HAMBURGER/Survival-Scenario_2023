using UnityEngine;

public class ItemMedicine : Item {
    public override int Count { get; set; }
    public override float Weight { get; set; }

    public override string ItemName { get; } = "약품";
    public override bool IsAcquirable { get; } = false;
    public override itemType ItemType { get; } = itemType.MEDICINE;
    public override eventType EventType { get; } = eventType.NONE;
    
    
    public ItemMedicine(int count = 0, float weight = 0f) {
        this.Count = count;
        this.Weight = weight;
    }
}