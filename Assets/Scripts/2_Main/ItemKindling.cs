using UnityEngine;

public class ItemKindling : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "불쏘시개";
    public bool IsAcquirable { get; } = false;
    public itemType ItemType { get; } = itemType.KINDLING;
    public eventType EventType { get; } = eventType.NONE;

    private int durability = 1;
    
    
    public ItemKindling(int count = 0, float weight = 0f) {
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