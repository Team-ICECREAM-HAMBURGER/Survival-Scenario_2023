using UnityEngine;

public class ItemPlasticBag : Item {
    public override string ItemName { get; set; }
    public override int Count { get; set; }
    public override float Weight { get; set; }
    
    public override bool IsAcquirable { get; } = true;
    public override itemType ItemType { get; } = itemType.PLASTIC_BAG;
    public override eventType EventType { get; } = eventType.FARMING;

    private readonly int _maxValue = 2;


    public ItemPlasticBag(string itemName = "비닐", int count = 0, float weight = 12f) {
        this.ItemName = itemName;
        this.Count = count;
        this.Weight = weight;
    }
    
    public override void ItemAcquire() {
        // Count Update -> Item get
        this.Count += Random.Range(1, (this._maxValue + 1));
    }
}