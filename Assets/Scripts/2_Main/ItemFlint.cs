using UnityEngine;

public class itemFlint : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public bool IsAcquirable { get; set; } = false;
    public itemType ItemType { get; set; } = itemType.FLINT;


    public itemFlint(float weight = 0f, int count = 0) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public void ItemFarming() {
        return;
    }
}