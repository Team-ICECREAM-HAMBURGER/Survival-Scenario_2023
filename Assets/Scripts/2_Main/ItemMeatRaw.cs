using UnityEngine;
using Random = UnityEngine.Random;

public class ItemMeatRaw : Item {
    public override int Count { get; set; }
    public override float Weight { get; set; }

    public override string ItemName { get; } = "생고기";
    public override bool IsAcquirable { get; } = true;
    public override itemType ItemType { get; } = itemType.RAW_MEAT;
    public override eventType EventType { get; } = eventType.HUNTING;

    private readonly int maxValue = 2;
    
    
    public ItemMeatRaw(int count = 0, float weight = 0f) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public override int ItemAcquire() {
        return this.Count += Random.Range(1, (this.maxValue + 1));
    }
}