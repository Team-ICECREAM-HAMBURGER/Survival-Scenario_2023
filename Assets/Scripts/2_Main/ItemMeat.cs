using UnityEngine;

public class itemMeat : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public bool IsAcquirable { get; set; }
    public bool IsRaw { get; set; }
    public itemType ItemType { get; set; }


    public itemMeat(float weight = 0f, int count = 0, bool isRaw = true) {
        this.Count = count;
        this.Weight = weight;
        this.IsRaw = isRaw;
        this.ItemType = itemType.MEAT;
    }
    
    public void ItemFarming() {
    }
}