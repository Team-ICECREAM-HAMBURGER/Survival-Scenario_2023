using UnityEngine;

public class ItemMre : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "비상식량";
    public bool IsAcquirable { get; } = false;
    public itemType ItemType { get; } = itemType.MRE;
    public eventType EventType { get; } = eventType.NONE;
    

    public ItemMre(int count = 0, float weight = 0f) {
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
