using UnityEngine;

public class itemHerbs : MonoBehaviour, IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    public bool IsAcquirable { get; set; } = true;
    public itemType ItemType { get; set; } = itemType.HERBS;

    private readonly int _maxValue;

    public itemHerbs(float weight = 0f, int count = 0) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public void ItemFarming() {
        this.Count += Random.Range(0, (this._maxValue + 1));
    }
}