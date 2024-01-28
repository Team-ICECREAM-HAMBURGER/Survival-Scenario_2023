using UnityEngine;
using Random = UnityEngine.Random;

public class ItemCan : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "깡통";
    public bool IsAcquirable { get; } = true;
    public ItemType ItemType { get; } = ItemType.CAN;
    public EventType EventType { get; } = EventType.FARMING;
    
    private readonly int maxValue = 2;
    
    
    public ItemCan(int count = 0, float weight = 8f) {
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