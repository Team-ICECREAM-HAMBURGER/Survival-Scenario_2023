using UnityEngine;

public class ItemTorch : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; }
    public bool IsAcquirable { get; } = false;
    public itemType ItemType { get; } = itemType.TORCH;

    private int _durability = 1;
    
    
    public ItemTorch(float weight = 0f, int count = 0) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public void ItemFarming() { 
        // IsAcquirable = false
        return;
    }
}