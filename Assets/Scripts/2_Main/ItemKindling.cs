using UnityEngine;

public class ItemKindling : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public ItemType ItemType { get; set; }

    public ItemKindling(float weight = 0f, int count = 0) {
        this.Count = count;
        this.Weight = weight;
        this.ItemType = ItemType.KINDLING;
    }
}