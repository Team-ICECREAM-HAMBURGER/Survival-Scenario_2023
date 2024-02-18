using UnityEngine;

public class ItemBottleFilled : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "물통";
    public GameTypeItem GameTypeItem { get; }
    public GameTypeBehaviourEvent EventType { get; }

    public bool IsAcquirable { get; } = false;
    // public GameTypeItem GameTypeItem { get; } = GameTypeItem.FILLED_BOTTLE;
    // public EventType EventType { get; } = EventType.NONE;

    
    public ItemBottleFilled(int count = 0, float weight = 0f) {
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