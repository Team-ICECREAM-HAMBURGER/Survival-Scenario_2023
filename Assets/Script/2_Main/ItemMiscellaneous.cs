using UnityEngine;

public class ItemMiscellaneous : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "잡동사니";
    public bool IsAcquirable { get; } = true;
    public itemType ItemType { get; } = itemType.MISCELLANEOUS;
    public eventType EventType { get; } = eventType.FARMING;

    private readonly int maxValue = 5;
    

    public ItemMiscellaneous(int count = 0, float weight = 15f) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public int ItemUse(int value) {
        this.Count -= value;
        
        return value;
    }
    
    public int ItemAcquire() {
        int acquireValue = Random.Range(1, (this.maxValue + 1));

        this.Count += acquireValue;

        return acquireValue;
    }
}