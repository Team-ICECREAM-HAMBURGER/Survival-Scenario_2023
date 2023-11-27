using UnityEngine;
using Random = UnityEngine.Random;

public class ItemCan : Item {
    public override int Count { get; set; }
    public override float Weight { get; }
    public override bool IsAcquirable { get; } = true;
    public override itemType ItemType { get; } = itemType.CAN;
    public override eventType EventType { get; } = eventType.FARMING;
    
    private readonly int _maxValue;
    
    
    public ItemCan(float weight = 8f, int count = 0, int maxValue = 2) {
        this.Count = count;
        this.Weight = weight;
        this._maxValue = maxValue;
    }
    
    public override void ItemAcquire() {
        // Count Update -> Item get
        this.Count += Random.Range(0, (this._maxValue + 1));
    }
}