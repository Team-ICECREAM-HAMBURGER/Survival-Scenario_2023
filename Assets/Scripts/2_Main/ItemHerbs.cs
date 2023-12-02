using UnityEngine;

public class ItemHerbs : Item {
    public override int Count { get; set; }
    public override float Weight { get; set; }

    public override string ItemName { get; } = "약초";
    public override bool IsAcquirable { get; } = true;
    public override itemType ItemType { get; } = itemType.HERBS;
    public override eventType EventType { get; } = eventType.FARMING;

    private readonly int maxValue = 2;
    
    
    public ItemHerbs(int count = 0, float weight = 5f) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public override int ItemAcquire() {
        // Count Update -> Item get
        return this.Count += Random.Range(1, (this.maxValue + 1));
    }
}