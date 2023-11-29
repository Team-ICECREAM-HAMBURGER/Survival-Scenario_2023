using UnityEngine;

public class ItemHandAxe : Item {
    public override string ItemName { get; set; }
    public override int Count { get; set; }
    public override float Weight { get; set; }
    
    public override bool IsAcquirable { get; } = false;
    public override itemType ItemType { get; } = itemType.HAND_AXE;
    public override eventType EventType { get; } = eventType.NONE;

    private int _durability = 5;

    
    public ItemHandAxe(string itemName = "손도끼", int count = 0, float weight = 0f) {
        this.ItemName = itemName;
        this.Count = count;
        this.Weight = weight;
    }
}