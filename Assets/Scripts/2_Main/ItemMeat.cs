using UnityEngine;
using Random = UnityEngine.Random;

public class itemMeat : Item {
    public override int Count { get; set; }
    public override float Weight { get; }
    public override bool IsAcquirable { get; } = true;
    public bool IsRaw { get; set; }
    public override itemType ItemType { get; } = itemType.MEAT;
    public override eventType EventType { get; } = eventType.HUNTING;

    private readonly int _maxValue;


    public itemMeat(float weight = 0f, int count = 0, bool isRaw = true) {
        this.Count = count;
        this.Weight = weight;
        this.IsRaw = isRaw;
    }
    
    public override void ItemAcquire() {
        this.Count += Random.Range(0, (this._maxValue + 1));
    }
}