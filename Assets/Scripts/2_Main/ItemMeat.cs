using UnityEngine;

public class ItemMeat : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public bool IsRaw { get; set; }
    public ItemType ItemType { get; set; }

    public ItemMeat(float weight = 0f, int count = 0, bool isRaw = true) {
        this.Count = count;
        this.Weight = weight;
        this.IsRaw = isRaw;
        this.ItemType = ItemType.MEAT;
    }
}