using UnityEngine;

public class ItemHuntingTool : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "사냥 도구";
    public GameTypeItem GameTypeItem { get; } = GameTypeItem.HUNTING_TOOL;
    public EventType EventType { get; } = EventType.NONE;

    private int durability = 0;
    
    
    public ItemHuntingTool(int count = 0, float weight = 0f) {
        this.Count = count;
        this.Weight = weight;
    }

    public int ItemUse(int value) {
        this.Count -= value;
        
        return value;
    }

    public int ItemAcquire() {
        return 0;
    }
}