using UnityEngine;

public class ItemStone : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "돌";
    public bool IsAcquirable { get; } = true;
    public itemType ItemType { get; } = itemType.STONE;
    public eventType EventType { get; } = eventType.FARMING;
    
    private readonly int maxValue = 5;

    
    public ItemStone(int count = 0, float weight = 18f) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public bool ItemUse() {
        return true;
    }
    
    public int ItemAcquire() {
        int acquireValue = Random.Range(1, (this.maxValue + 1));

        this.Count += acquireValue;

        return acquireValue;
    }
}