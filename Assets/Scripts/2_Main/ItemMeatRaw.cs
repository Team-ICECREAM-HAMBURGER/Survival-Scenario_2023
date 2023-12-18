using UnityEngine;
using Random = UnityEngine.Random;

public class ItemMeatRaw : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "생고기";
    public bool IsAcquirable { get; } = true;
    public itemType ItemType { get; } = itemType.RAW_MEAT;
    public eventType EventType { get; } = eventType.HUNTING;

    private readonly int maxValue = 2;
    
    
    public ItemMeatRaw(int count = 0, float weight = 0f) {
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