using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemMeatRaw : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "생고기";
    public itemType ItemType { get; } = itemType.RAW_MEAT;
    public eventType EventType { get; } = eventType.HUNTING;

    private readonly int maxValue = 2;
    
    
    public ItemMeatRaw(int count = 0, float weight = 0f) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public bool ItemUse(int value) {
        return true;
    }
    
    public int ItemAcquire() {
        int value = Random.Range(1, (this.maxValue + 1));

        this.Count += value;

        return value;
    }
}