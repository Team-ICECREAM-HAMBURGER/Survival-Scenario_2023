using UnityEngine;

public class ItemMiscellaneous : Item {
    public override int Count { get; set; }
    public override float Weight { get; set; }

    public override string ItemName { get; } = "잡동사니";
    public override bool IsAcquirable { get; } = true;
    public override itemType ItemType { get; } = itemType.MISCELLANEOUS;
    public override eventType EventType { get; } = eventType.FARMING;

    private readonly int maxValue = 5;
    

    public ItemMiscellaneous(int count = 0, float weight = 15f) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public override void ItemAcquire() {
        // Count Update -> Item get
        this.Count += Random.Range(1, (this.maxValue + 1));
    }
}