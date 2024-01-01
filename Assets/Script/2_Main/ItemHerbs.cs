using UnityEngine;

public class ItemHerbs : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "약초";
    public bool IsAcquirable { get; } = true;
    public itemType ItemType { get; } = itemType.HERBS;
    public eventType EventType { get; } = eventType.FARMING;

    private readonly int maxValue = 2;
    
    
    public ItemHerbs(int count = 0, float weight = 5f) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public bool ItemUse(int value) {
        return true;
    }

    public int ItemAcquire() {
        int acquireValue = Random.Range(1, (this.maxValue + 1));

        this.Count += acquireValue;

        return acquireValue;
    }
}