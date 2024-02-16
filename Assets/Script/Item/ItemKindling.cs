using UnityEngine;

public class ItemKindling : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "불쏘시개";
    public bool IsAcquirable { get; } = false;
    public GameTypeItem GameTypeItem { get; } = GameTypeItem.KINDLING;
    public EventType EventType { get; } = EventType.NONE;

    private int durability = 1;
    
    
    public ItemKindling(int count = 100, float weight = 0f) {
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