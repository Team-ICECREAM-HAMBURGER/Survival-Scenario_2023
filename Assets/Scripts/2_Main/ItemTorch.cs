using UnityEngine;

public class ItemTorch : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "횃불";
    public bool IsAcquirable { get; } = false;
    public itemType ItemType { get; } = itemType.TORCH;
    public eventType EventType { get; } = eventType.NONE;   // TODO: eventType.CRAFT

    private int durability = 1;
    
    
    public ItemTorch(int count = 0, float weight = 0f) {
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