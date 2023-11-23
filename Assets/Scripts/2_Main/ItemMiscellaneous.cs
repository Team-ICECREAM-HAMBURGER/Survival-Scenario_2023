using UnityEngine;

public class itemMiscellaneous : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public bool IsAcquirable { get; set; }
    public itemType ItemType { get; set; }


    public itemMiscellaneous(float weight = 0f, int count = 0) {
        this.Count = count;
        this.Weight = weight;
        this.ItemType = itemType.MISCELLANEOUS;
    }
    
    public void ItemFarming() {
    }
}