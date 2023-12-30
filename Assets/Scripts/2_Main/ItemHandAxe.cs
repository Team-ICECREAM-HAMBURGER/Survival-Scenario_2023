using UnityEngine;

public class ItemHandAxe : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "손도끼";
    public bool IsAcquirable { get; } = false;
    public itemType ItemType { get; } = itemType.HAND_AXE;
    public eventType EventType { get; } = eventType.NONE;

    private int durability = 5;
    
    
    public ItemHandAxe(int count = 0, float weight = 0f) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public bool ItemUse(int value) {
        return true;
    }
    
    public int ItemAcquire() {
        return 0;
    }
}