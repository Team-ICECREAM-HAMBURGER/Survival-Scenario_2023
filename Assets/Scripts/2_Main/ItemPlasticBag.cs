using UnityEngine;

public class ItemPlasticBag : Item {
    public override int Count { get; set; }
    public override float Weight { get; }
    public override bool IsAcquirable { get; } = true;
    public override itemType ItemType { get; } = itemType.PLASTIC_BAG;
    public override eventType EventType { get; } = eventType.FARMING;

    private readonly int _maxValue;


    public ItemPlasticBag(float weight = 12f, int count = 0) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public override void ItemAcquire() {
        // Count Update -> Item get
        this.Count += Random.Range(0, (this._maxValue + 1));
    }
}