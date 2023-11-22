using UnityEngine;

public class ItemHerbs : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public ItemType ItemType { get; set; }

    public ItemHerbs(float weight = 0f, int count = 0) {
        this.Count = count;
        this.Weight = weight;
        this.ItemType = ItemType.HERBS;
    }
}