using UnityEngine;

public class itemTorch : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public bool IsAcquirable { get; set; }
    public itemType ItemType { get; set; }
    
    
    public itemTorch(float weight = 0f, int count = 0, bool isAcquirable = false) {
        this.Count = count;
        this.Weight = weight;
        this.IsAcquirable = isAcquirable;
        this.ItemType = itemType.TORCH;
    }
    
    public void ItemFarming() {
    }
}