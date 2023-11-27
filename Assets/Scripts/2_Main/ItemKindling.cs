using UnityEngine;

public class ItemKindling : Item {
    public override int Count { get; set; }
    public override float Weight { get; }
    public override bool IsAcquirable { get; } = false;
    public override itemType ItemType { get; } = itemType.KINDLING;
    public override eventType EventType { get; } = eventType.NONE;

    public int Durability { get; set; }

    
    public ItemKindling(float weight = 0f, int count = 0, int durability = 1) {
        this.Count = count;
        this.Weight = weight;
    }
}