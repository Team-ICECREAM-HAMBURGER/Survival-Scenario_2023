using UnityEngine;

public class ItemBottle : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public bool IsAcquirable { get; set; }
    public bool IsEmpty { get; set; }
    public ItemType ItemType { get; set; }
    
    
    public ItemBottle(float weight = 0f, int count = 0, bool isEmpty = true, bool isAcquirable = true) {
        this.Count = count;
        this.Weight = weight;
        this.IsEmpty = isEmpty;
        this.IsAcquirable = isAcquirable;
        this.ItemType = ItemType.BOTTLE;
    }

    public void ItemFarming() {
    }
}