using UnityEngine;

public class ItemFireTool : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; }
    public bool IsAcquirable { get; } = false;
    public int Durability { get; set; }
    public itemType ItemType { get; } = itemType.FIRE_TOOL;


    public ItemFireTool(float weight = 0f, int count = 0, int durability = 1) {
        this.Count = count;
        this.Weight = weight;
        this.Durability = durability;
    }
    
    public void ItemFarming() {
        return;
    }
}