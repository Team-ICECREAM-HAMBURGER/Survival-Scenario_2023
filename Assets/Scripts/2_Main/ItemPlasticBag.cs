using UnityEngine;

public class ItemPlasticBag : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "비닐";
    public bool IsAcquirable { get; } = true;
    public itemType ItemType { get; } = itemType.PLASTIC_BAG;
    public eventType EventType { get; } = eventType.FARMING;

    private readonly int maxValue = 2;

    
    public ItemPlasticBag(int count = 0, float weight = 12f) {
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