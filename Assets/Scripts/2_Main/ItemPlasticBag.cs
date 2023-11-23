using UnityEngine;

public class ItemPlasticBag : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public bool IsAcquirable { get; set; }
    public ItemType ItemType { get; set; }


    public ItemPlasticBag(float weight = 0f, int count = 0) {
        this.Count = count;
        this.Weight = weight;
        this.ItemType = ItemType.PLASTIC_BAG;
    }
    
    public void ItemFarming() {
    }
}