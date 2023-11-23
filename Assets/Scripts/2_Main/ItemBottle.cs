using UnityEngine;

public class itemBottle : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public bool IsAcquirable { get; set; }
    public bool IsEmpty { get; set; }
    public itemType ItemType { get; set; }
    
    
    public itemBottle(float weight = 0f, int count = 0, bool isEmpty = true, bool isAcquirable = true) {
        this.Count = count;
        this.Weight = weight;
        this.IsEmpty = isEmpty;
        this.IsAcquirable = isAcquirable;
        this.ItemType = itemType.BOTTLE;
    }

    public void ItemFarming() {
    }
}