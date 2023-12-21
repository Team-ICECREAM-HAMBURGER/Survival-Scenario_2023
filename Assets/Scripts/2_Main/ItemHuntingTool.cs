using UnityEngine;

public class ItemHuntingTool : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "사냥 도구";
    public itemType ItemType { get; } = itemType.HUNTING_TOOL;
    public eventType EventType { get; } = eventType.NONE;

    private int durability = 0;
    
    
    public ItemHuntingTool(int count = 0, float weight = 0f) {
        this.Count = count;
        this.Weight = weight;
    }

    public bool ItemUse() {
        return true;
    }

    public int ItemAcquire() {
        return 0;
    }
}