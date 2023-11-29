using UnityEngine;

public class ItemBottle : Item {
    public override string ItemName { get; set; }
    public override int Count { get; set; }
    public override float Weight { get; set; }
    
    public override bool IsAcquirable { get; } = false;
    public override itemType ItemType { get; } = itemType.BOTTLE;
    public override eventType EventType { get; } = eventType.NONE;

    private bool _isEmpty;


    public ItemBottle(string itemName = "물통", int count = 0, float weight = 0f) {
        this.ItemName = itemName;
        this.Count = count;
        this.Weight = weight;
    }
}