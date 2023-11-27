using UnityEngine;

public class itemMre : Item {
    public override int Count { get; set; }
    public override float Weight { get; }
    public override bool IsAcquirable { get; } = false;
    public override itemType ItemType { get; } = itemType.MRE;
    public override eventType EventType { get; } = eventType.NONE;


    public itemMre(float weight = 0f, int count = 0) {
        this.Count = count;
        this.Weight = weight;
    }
}
