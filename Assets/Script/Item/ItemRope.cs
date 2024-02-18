using UnityEngine;

public class ItemRope : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "노끈";
    public bool IsAcquirable { get; } = true;
    public GameTypeItem GameTypeItem { get; } = GameTypeItem.ROPE;
    public GameTypeBehaviourEvent EventType { get; }

    private readonly int maxValue = 3;
    

    public ItemRope(int count = 0, float weight = 7f) {
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