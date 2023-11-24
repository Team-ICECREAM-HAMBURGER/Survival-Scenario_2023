using UnityEngine;

public class ItemKindling : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; }
    public bool IsAcquirable { get; } = false;
    public int Durability { get; set; }
    public itemType ItemType { get; } = itemType.KINDLING;


    public ItemKindling(float weight = 0f, int count = 0, int durability = 1) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public void ItemFarming() {
        return;
    }
}