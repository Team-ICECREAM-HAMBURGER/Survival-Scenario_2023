using UnityEngine;

public class ItemMedicine : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "약품";
    public bool IsAcquirable { get; } = false;
    public itemType ItemType { get; } = itemType.MEDICINE;
    public eventType EventType { get; } = eventType.NONE;
    
    public ItemMedicine(int count = 0, float weight = 0f) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public bool ItemUse() {
        return true;
    }

    public int ItemAcquire() {
        return 0;
    }
}