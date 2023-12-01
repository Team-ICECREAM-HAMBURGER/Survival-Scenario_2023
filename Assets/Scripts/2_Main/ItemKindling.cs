using UnityEngine;

public class ItemKindling : Item {
    public override int Count { get; set; }
    public override float Weight { get; set; }

    public override string ItemName { get; } = "불쏘시개";
    public override bool IsAcquirable { get; } = false;
    public override itemType ItemType { get; } = itemType.KINDLING;
    public override eventType EventType { get; } = eventType.NONE;

    private int durability = 1;
    
    
    public ItemKindling(int count = 0, float weight = 0f) {
        this.Count = count;
        this.Weight = weight;
    }
}