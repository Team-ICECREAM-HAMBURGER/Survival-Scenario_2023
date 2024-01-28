using UnityEngine;

public class ItemPlasticBag : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "비닐";
    public bool IsAcquirable { get; } = true;
    public ItemType ItemType { get; } = ItemType.PLASTIC_BAG;
    public EventType EventType { get; } = EventType.FARMING;

    private readonly int maxValue = 2;

    
    public ItemPlasticBag(int count = 0, float weight = 12f) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public int ItemUse(int value) {
        this.Count -= value;
        
        return value;
    }
    
    public int ItemAcquire() {
        var acquireValue = Random.Range(1, (this.maxValue + 1));

        this.Count += acquireValue;

        return acquireValue;
    }
}