using UnityEngine;
using Random = UnityEngine.Random;

public class ItemCan : Item {
    public override int Count { get; set; }
    public override float Weight { get; set; }

    public override string ItemName { get; } = "깡통";
    public override bool IsAcquirable { get; } = true;
    public override itemType ItemType { get; } = itemType.CAN;
    public override eventType EventType { get; } = eventType.FARMING;
    
    private readonly int maxValue = 2;
    
    
    public ItemCan(int count = 0, float weight = 8f) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public override int ItemAcquire() {
        // Count Update -> Item get
        return this.Count += Random.Range(1, (this.maxValue + 1));
    }
}