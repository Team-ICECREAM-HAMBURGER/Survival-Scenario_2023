using UnityEngine;
using Random = UnityEngine.Random;

public class ItemWood : Item {
    public override string ItemName { get; set; }
    public override int Count { get; set; }
    public override float Weight { get; set; }
    
    public override bool IsAcquirable { get; } = true;
    public override itemType ItemType { get; } = itemType.WOOD;
    public override eventType EventType { get; } = eventType.FARMING;

    private readonly int _maxValue = 3;

    
    public ItemWood(string itemName = "나무", int count = 0, float weight = 25f) {
        this.ItemName = itemName;
        this.Count = count;
        this.Weight = weight;
    }

    public override void ItemAcquire() {
        // Count Update -> Item get
        this.Count += Random.Range(1, (this._maxValue + 1));
    }
}