using UnityEngine;

public class ItemPlasticBag : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "비닐";
    public GameTypeItem GameTypeItem { get; }
    public GameTypeBehaviourEvent EventType { get; }
    public bool IsAcquirable { get; } = true;

    private readonly int maxValue = 2;

    
    public ItemPlasticBag(int count = 0, float weight = 12f) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public int ItemUse(int value) {
        this.Count -= value;
        
        return value;
    }
    
    public int ItemAcquire() {
        var acquireValue = Random.Range(1, (this.maxValue + 1));

        this.Count += acquireValue;

        return acquireValue;
    }
}