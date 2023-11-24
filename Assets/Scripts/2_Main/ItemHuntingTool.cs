using UnityEngine;

public class itemHuntingTool : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public bool IsAcquirable { get; set; } = false;
    public int Durability { get; set; }
    public itemType ItemType { get; } = itemType.HUNTING_TOOL;


    public itemHuntingTool(float weight = 0f, int count = 0, int durability = 1) {
        this.Count = count;
        this.Weight = weight;
        this.Durability = durability;
    }
    
    public void ItemFarming() {
        return;
    }
}