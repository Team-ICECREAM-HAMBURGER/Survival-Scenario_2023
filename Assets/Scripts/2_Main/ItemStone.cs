using UnityEngine;

public class ItemStone : Item {
    public override int Count { get; set; }
    public override float Weight { get; set; }

    public override string ItemName { get; } = "돌";
    public override bool IsAcquirable { get; } = true;
    public override itemType ItemType { get; } = itemType.STONE;
    public override eventType EventType { get; } = eventType.FARMING;

    private readonly int maxValue = 5;

    
    public ItemStone(int count = 0, float weight = 18f) {
        this.Count = count;
        this.Weight = weight;
    }

    public override void ItemAcquire() {
        // Count Update -> Item get
        this.Count += Random.Range(1, (this.maxValue + 1));
    }
}