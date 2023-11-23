using UnityEngine;

public class ItemFireTool : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public bool IsAcquirable { get; set; }
    public ItemType ItemType { get; set; }


    public ItemFireTool(float weight = 0f, int count = 0) {
        this.Count = count;
        this.Weight = weight;
        this.ItemType = ItemType.FIRE_TOOL;
    }
    
    public void ItemFarming() {
    }
}