using UnityEngine;
using Random = UnityEngine.Random;

public class ItemWood : Item {
    public override int Count { get; set; }
    public override float Weight { get; set; }

    public override string ItemName { get; } = "나무";
    public override bool IsAcquirable { get; } = true;
    public override itemType ItemType { get; } = itemType.WOOD;
    public override eventType EventType { get; } = eventType.FARMING;

    private readonly int maxValue = 3;
    
    
    public ItemWood(int count = 0, float weight = 25f) {
        this.Count = count;
        this.Weight = weight;
    }

    public override int ItemAcquire() {
        // Count Update -> Item get
        return this.Count += Random.Range(1, (this.maxValue + 1));
    }
}