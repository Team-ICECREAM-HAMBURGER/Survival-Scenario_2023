using UnityEngine;

public class ItemBottle : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; }
    public bool IsAcquirable { get; } = false;
    public bool IsEmpty { get; set; }
    public itemType ItemType { get; } = itemType.BOTTLE;
    
    
    public ItemBottle(float weight = 0f, int count = 0, bool isEmpty = true) {
        this.Count = count;
        this.Weight = weight;
        this.IsEmpty = isEmpty;
    }

    public void ItemFarming() {
        // IsAcquirable = false
        return;
    }
}