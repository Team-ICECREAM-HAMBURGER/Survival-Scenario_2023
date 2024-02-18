using UnityEngine;
using Random = UnityEngine.Random;

public class ItemMeatCooked : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "익힌 고기";
    public GameTypeItem GameTypeItem { get; }
    public GameTypeBehaviourEvent EventType { get; }
    public bool IsAcquirable { get; } = true;


    private readonly int maxValue = 3;
    
    
    public ItemMeatCooked(int count = 0, float weight = 0f) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public int ItemUse(int value) {
        this.Count -= value;
        
        return value;
    }
    
    public int ItemAcquire() {
        var acquireValue = 1;
        
        this.Count += acquireValue;

        return acquireValue;
    }
}