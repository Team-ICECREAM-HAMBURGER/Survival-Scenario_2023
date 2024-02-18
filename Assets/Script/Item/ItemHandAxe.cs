using UnityEngine;

public class ItemHandAxe : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "손도끼";
    public GameTypeItem GameTypeItem { get; }
    public GameTypeBehaviourEvent EventType { get; }
    public bool IsAcquirable { get; } = false;


    private int durability = 5;
    
    
    public ItemHandAxe(int count = 0, float weight = 0f) {
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