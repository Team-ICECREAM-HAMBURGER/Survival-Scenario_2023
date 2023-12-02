using UnityEngine;

public class ItemPlasticBag : Item {
    public override int Count { get; set; }
    public override float Weight { get; set; }

    public override string ItemName { get; } = "비닐";
    public override bool IsAcquirable { get; } = true;
    public override itemType ItemType { get; } = itemType.PLASTIC_BAG;
    public override eventType EventType { get; } = eventType.FARMING;

    private readonly int maxValue = 2;

    
    public ItemPlasticBag(int count = 0, float weight = 12f) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public override int ItemAcquire() {
        // Count Update -> Item get
        return this.Count += Random.Range(1, (this.maxValue + 1));
    }
}