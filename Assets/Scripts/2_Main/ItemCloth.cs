using UnityEngine;
using Random = UnityEngine.Random;

public class ItemCloth : Item {
    public override int Count { get; set; }
    public override float Weight { get; }
    public override bool IsAcquirable { get; } = true;
    public override itemType ItemType { get; } = itemType.CLOTH;
    public override eventType EventType { get; } = eventType.FARMING;

    private readonly int _maxValue;
    
    
    public ItemCloth(float weight = 10f, int count = 0, int maxValue = 2) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public override void ItemAcquire() {
        // Count Update -> Item get
        this.Count += Random.Range(0, (this._maxValue + 1));
    }
}