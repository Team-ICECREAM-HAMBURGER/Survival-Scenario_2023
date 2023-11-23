using UnityEngine;

public class itemStone : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public bool IsAcquirable { get; set; }
    public itemType ItemType { get; set; }

    
    public itemStone(float weight = 0f, int count = 0, bool isAcquirable = true) {
        this.Count = count;
        this.Weight = weight;
        this.IsAcquirable = isAcquirable;
        this.ItemType = itemType.STONE;
    }

    public void ItemFarming() {
    }
}