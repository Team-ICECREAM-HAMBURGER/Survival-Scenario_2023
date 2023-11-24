using UnityEngine;
using Random = UnityEngine.Random;

public class ItemWood : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; }
    public bool IsAcquirable { get; } = true;
    public itemType ItemType { get; } = itemType.WOOD;

    private readonly int _maxValue;

    
    public ItemWood(float weight = 0f, int count = 0, int maxValue = 3) {
        this.Count = count;
        this.Weight = weight;
        this._maxValue = maxValue;
    }

    public void ItemFarming() {
        // Count Update -> Item get
        this.Count += Random.Range(0, (this._maxValue + 1));
    }
}