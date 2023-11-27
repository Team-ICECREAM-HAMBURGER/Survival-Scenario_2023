using UnityEngine;

public class itemMedicine : Item {
    public override int Count { get; set; }
    public override float Weight { get; }
    public override bool IsAcquirable { get; } = false;
    public override itemType ItemType { get; } = itemType.MEDICINE;
    public override eventType EventType { get; } = eventType.NONE;


    public itemMedicine(float weight = 0f, int count = 0) {
        this.Count = count;
        this.Weight = weight;
    }
}