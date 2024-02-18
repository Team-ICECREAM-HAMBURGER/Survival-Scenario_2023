using UnityEngine;

public class ItemFireTool : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "점화 도구";
    public GameTypeItem GameTypeItem { get; }
    public GameTypeBehaviourEvent EventType { get; }
    public bool IsAcquirable { get; } = false;


    private int durability = 1;
    

    public ItemFireTool(int count = 100, float weight = 0f) {
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