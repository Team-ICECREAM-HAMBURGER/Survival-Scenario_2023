using UnityEngine;
using Random = UnityEngine.Random;

public class ItemWood : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public bool IsAcquirable { get; set; }
    public ItemType ItemType { get; set; }

    private readonly int maxCount = 5;

    public ItemWood(float weight = 0f, int count = 0, bool isAcquirable = true) {
        this.Count = count;
        this.Weight = weight;
        this.IsAcquirable = isAcquirable;
        this.ItemType = ItemType.WOOD;
    }

    public void ItemFarming() {
        this.Count += Random.Range(1, this.maxCount);
    }
}