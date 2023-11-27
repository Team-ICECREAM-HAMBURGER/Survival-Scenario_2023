using UnityEngine;

public class ItemBottle : Item {
    public override int Count { get; set; }
    public override float Weight { get; }
    public override bool IsAcquirable { get; } = false;
    public bool IsEmpty { get; set; }
    public override itemType ItemType { get; } = itemType.BOTTLE;
    public override eventType EventType { get; } = eventType.NONE;


    public ItemBottle(float weight = 0f, int count = 0, bool isEmpty = true) {
        this.Count = count;
        this.Weight = weight;
        this.IsEmpty = isEmpty;
    }
}