using UnityEngine;

public class itemMre : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public bool IsAcquirable { get; set; }
    public itemType ItemType { get; set; }


    public itemMre(float weight = 0f, int count = 0) {
        this.Count = count;
        this.Weight = weight;
        this.ItemType = itemType.MRE;
    }
    
    public void ItemFarming() {
    }
}
