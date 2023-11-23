using UnityEngine;
using Random = UnityEngine.Random;

public class itemWood : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public bool IsAcquirable { get; set; } = true;
    public itemType ItemType { get; set; }

    private readonly int _maxValue;

    
    public itemWood(float weight = 100f, int count = 0, int maxValue = 3) {
        this.Count = count;
        this.Weight = weight;
        this.ItemType = itemType.WOOD;
        this._maxValue = maxValue;
    }

    public void ItemFarming() {
        // Count Update -> Item get
        this.Count += Random.Range(0, (this._maxValue + 1));
    }
}