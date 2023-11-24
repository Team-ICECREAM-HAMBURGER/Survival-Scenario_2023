using UnityEngine;
using Random = UnityEngine.Random;

public class itemCloth : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; }
    public bool IsAcquirable { get; } = true;
    public itemType ItemType { get; } = itemType.CLOTH;

    private readonly int _maxValue;
    
    
    public itemCloth(float weight = 0f, int count = 0, int maxValue = 2) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public void ItemFarming() {
        // Count Update -> Item get
        this.Count += Random.Range(0, (this._maxValue + 1));
    }
}