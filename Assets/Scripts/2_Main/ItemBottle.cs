using UnityEngine;

public class ItemBottle : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public bool IsEmpty { get; set; }
    public ItemType ItemType { get; set; }

    public ItemBottle(float weight = 0f, int count = 0, bool isEmpty = true) {
        this.Count = count;
        this.Weight = weight;
        this.IsEmpty = isEmpty;
        this.ItemType = ItemType.BOTTLE;
    }
}