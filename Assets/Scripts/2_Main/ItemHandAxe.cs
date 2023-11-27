using UnityEngine;

public class itemHandAxe : Item {
    public override int Count { get; set; }
    public override float Weight { get; }
    public override bool IsAcquirable { get; } = false;
    public int Durability { get; set; }
    public override itemType ItemType { get; } = itemType.HAND_AXE;
    public override eventType EventType { get; } = eventType.NONE;


    public itemHandAxe(float weight = 0f, int count = 0, int durability = 5) {
        this.Count = count;
        this.Weight = weight;
        this.Durability = durability;
    }
}