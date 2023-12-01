using UnityEngine;
using Random = UnityEngine.Random;

public class ItemMeatCooked : Item {
    public override int Count { get; set; }
    public override float Weight { get; set; }

    public override string ItemName { get; } = "익힌 고기";
    public override bool IsAcquirable { get; } = true;
    public override itemType ItemType { get; } = itemType.COOKED_MEAT;
    public override eventType EventType { get; } = eventType.HUNTING;

    private readonly int maxValue = 3;
    
    
    public ItemMeatCooked(int count = 0, float weight = 0f) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public override void ItemAcquire() {
        this.Count += Random.Range(1, (this.maxValue + 1));
    }
}