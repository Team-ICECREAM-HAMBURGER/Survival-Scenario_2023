using UnityEngine;

public class ItemTorch : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public bool IsAcquirable { get; set; }
    public ItemType ItemType { get; set; }
    
    
    public ItemTorch(float weight = 0f, int count = 0, bool isAcquirable = false) {
        this.Count = count;
        this.Weight = weight;
        this.IsAcquirable = isAcquirable;
        this.ItemType = ItemType.TORCH;
    }
    
    public void ItemFarming() {
    }
}