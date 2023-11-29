using UnityEngine;

public class ItemHuntingTool : Item {
    public override string ItemName { get; set; }
    public override int Count { get; set; }
    public override float Weight { get; set; }
    
    public override bool IsAcquirable { get; } = false;
    public override itemType ItemType { get; } = itemType.HUNTING_TOOL;
    public override eventType EventType { get; } = eventType.NONE;

    private int _durability = 1;

    public ItemHuntingTool(string itemName = "사냥 도구", int count = 0, float weight = 0f) {
        this.ItemName = itemName;
        this.Count = count;
        this.Weight = weight;
    }
}