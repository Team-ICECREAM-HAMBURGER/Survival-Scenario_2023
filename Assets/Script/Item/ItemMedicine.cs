using UnityEngine;

public class ItemMedicine : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "약품";
    public bool IsAcquirable { get; } = false;
    public GameTypeItem GameTypeItem { get; } = GameTypeItem.MEDICINE;
    public EventType EventType { get; } = EventType.NONE;
    
    public ItemMedicine(int count = 0, float weight = 0f) {
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