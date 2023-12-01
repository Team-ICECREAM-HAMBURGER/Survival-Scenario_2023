using UnityEngine;

public class ItemHandAxe : Item {
    public override int Count { get; set; }
    public override float Weight { get; set; }

    public override string ItemName { get; } = "손도끼";
    public override bool IsAcquirable { get; } = false;
    public override itemType ItemType { get; } = itemType.HAND_AXE;
    public override eventType EventType { get; } = eventType.NONE;

    private int durability = 5;
    
    
    public ItemHandAxe(int count = 0, float weight = 0f) {
        this.Count = count;
        this.Weight = weight;
    }
}