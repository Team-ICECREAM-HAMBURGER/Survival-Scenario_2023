using UnityEngine;

public class ItemFlint : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public ItemType ItemType { get; set; }

    public ItemFlint(float weight = 0f, int count = 0) {
        this.Count = count;
        this.Weight = weight;
        this.ItemType = ItemType.FLINT;
    }
}