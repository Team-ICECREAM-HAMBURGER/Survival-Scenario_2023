using UnityEngine;
using Random = UnityEngine.Random;

public class ItemWood : Item {
    public override int Count { get; set; }
    public override float Weight { get; }
    public override bool IsAcquirable { get; } = true;
    public override itemType ItemType { get; } = itemType.WOOD;
    public override eventType EventType { get; } = eventType.FARMING;

    private readonly int _maxValue;

    
    public ItemWood(float weight = 25f, int count = 0, int maxValue = 3) {
        this.Count = count;
        this.Weight = weight;
        this._maxValue = maxValue;
    }

    public override void ItemAcquire() {
        // Count Update -> Item get
        this.Count += Random.Range(0, (this._maxValue + 1));
    }
}