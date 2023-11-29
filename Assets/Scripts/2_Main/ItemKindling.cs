using UnityEngine;

public class ItemKindling : Item {
    public override string ItemName { get; set; }
    public override int Count { get; set; }
    public override float Weight { get; set; }
    
    public override bool IsAcquirable { get; } = false;
    public override itemType ItemType { get; } = itemType.KINDLING;
    public override eventType EventType { get; } = eventType.NONE;

    private int _durability = 1;

    
    public ItemKindling(string itemName = "불쏘시개", int count = 0, float weight = 0f) {
        this.ItemName = itemName;
        this.Count = count;
        this.Weight = weight;
    }
}