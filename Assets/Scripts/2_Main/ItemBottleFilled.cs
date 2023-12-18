using UnityEngine;

public class ItemBottleFilled : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "물통";
    public bool IsAcquirable { get; } = false;
    public itemType ItemType { get; } = itemType.FILLED_BOTTLE;
    public eventType EventType { get; } = eventType.NONE;

    
    public ItemBottleFilled(int count = 0, float weight = 0f) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public int ItemUse() {
        return 0;
    }
    
    public string ItemAcquire() {
        return "";
    }
}