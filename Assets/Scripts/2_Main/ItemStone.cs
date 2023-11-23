using UnityEngine;

public class ItemStone : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public bool IsAcquirable { get; set; }
    public ItemType ItemType { get; set; }

    
    public ItemStone(float weight = 0f, int count = 0, bool isAcquirable = true) {
        this.Count = count;
        this.Weight = weight;
        this.IsAcquirable = isAcquirable;
        this.ItemType = ItemType.STONE;
    }

    public void ItemFarming() {
    }
}