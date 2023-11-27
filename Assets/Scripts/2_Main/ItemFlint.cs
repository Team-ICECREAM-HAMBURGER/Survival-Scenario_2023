using UnityEngine;

public class itemFlint : Item {
    public override int Count { get; set; }
    public override float Weight { get; }
    public override bool IsAcquirable { get; } = false;
    public override itemType ItemType { get; } = itemType.FLINT;
    public override eventType EventType { get; } = eventType.NONE;


    public itemFlint(float weight = 0f, int count = 0) {
        this.Count = count;
        this.Weight = weight;
    }
}