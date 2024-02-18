using UnityEngine;

public class ItemMre : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "비상식량";
    public bool IsAcquirable { get; } = false;
    public GameTypeItem GameTypeItem { get; } = GameTypeItem.MRE;
    public GameTypeBehaviourEvent EventType { get; }


    public ItemMre(int count = 0, float weight = 0f) {
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
