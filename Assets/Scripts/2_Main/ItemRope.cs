using UnityEngine;

public class ItemRope : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "노끈";
    public bool IsAcquirable { get; } = true;
    public itemType ItemType { get; } = itemType.ROPE;
    public eventType EventType { get; } = eventType.FARMING;
    
    private readonly int maxValue = 3;
    

    public ItemRope(int count = 0, float weight = 7f) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public int ItemUse() {
        return 0;
    }
    
    public string ItemAcquire() {
        int acquireValue = Random.Range(1, (this.maxValue + 1));

        this.Count += acquireValue;
        
        return "- " + this.ItemName + " " + acquireValue.ToString("+#; -#; 0") + "\n";
    }
}