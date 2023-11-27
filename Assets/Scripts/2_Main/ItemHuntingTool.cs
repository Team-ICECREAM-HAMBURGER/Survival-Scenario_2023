using UnityEngine;

public class itemHuntingTool : Item {
    public override int Count { get; set; }
    public override float Weight { get; }
    public override bool IsAcquirable { get; } = false;
    public int Durability { get; set; }
    public override itemType ItemType { get; } = itemType.HUNTING_TOOL;
    public override eventType EventType { get; } = eventType.NONE;


    public itemHuntingTool(float weight = 0f, int count = 0, int durability = 1) {
        this.Count = count;
        this.Weight = weight;
        this.Durability = durability;
    }
}