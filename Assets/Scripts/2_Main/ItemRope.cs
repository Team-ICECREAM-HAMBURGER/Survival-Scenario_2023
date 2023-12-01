using UnityEngine;

public class ItemRope : Item {
    public override int Count { get; set; }
    public override float Weight { get; set; }

    public override string ItemName { get; } = "노끈";
    public override bool IsAcquirable { get; } = true;
    public override itemType ItemType { get; } = itemType.ROPE;
    public override eventType EventType { get; } = eventType.FARMING;

    private readonly int maxValue = 3;
    

    public ItemRope(int count = 0, float weight = 7f) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public override void ItemAcquire() {
        // Count Update -> Item get
        this.Count += Random.Range(1, (this.maxValue + 1));
    }
}