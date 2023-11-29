using UnityEngine;

public class ItemMiscellaneous : Item {
    public override string ItemName { get; set; }
    public override int Count { get; set; }
    public override float Weight { get; set; }
    
    public override bool IsAcquirable { get; } = true;
    public override itemType ItemType { get; } = itemType.MISCELLANEOUS;
    public override eventType EventType { get; } = eventType.FARMING;

    private readonly int _maxValue = 5;


    public ItemMiscellaneous(string itemName = "잡동사니", int count = 0, float weight = 0f) {
        this.ItemName = itemName;
        this.Count = count;
        this.Weight = weight;
    }
    
    public override void ItemAcquire() {
        // Count Update -> Item get
        this.Count += Random.Range(0, (this._maxValue + 1));
    }
}