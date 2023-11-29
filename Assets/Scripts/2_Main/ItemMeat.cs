using UnityEngine;
using Random = UnityEngine.Random;

public class ItemMeat : Item {
    public override string ItemName { get; set; }
    public override int Count { get; set; }
    public override float Weight { get; set; }
    
    public override bool IsAcquirable { get; } = true;
    public override itemType ItemType { get; } = itemType.MEAT;
    public override eventType EventType { get; } = eventType.HUNTING;

    private readonly int _maxValue = 3;
    private bool _isRaw = true;

    
    public ItemMeat(string itemName = "고기", int count = 0, float weight = 0f) {
        this.ItemName = itemName;
        this.Count = count;
        this.Weight = weight;
    }
    
    public override void ItemAcquire() {
        this.Count += Random.Range(0, (this._maxValue + 1));
    }
}