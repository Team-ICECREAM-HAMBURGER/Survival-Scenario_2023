using UnityEngine;

public class ItemTorch : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "횃불";
    public bool IsAcquirable { get; } = false;
    public GameTypeItem GameTypeItem { get; } = GameTypeItem.TORCH;
    public GameTypeBehaviourEvent EventType { get; }

    private int durability = 1;
    
    
    public ItemTorch(int count = 0, float weight = 0f) {
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