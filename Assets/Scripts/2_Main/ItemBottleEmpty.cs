using UnityEngine;

public class ItemBottleEmpty : Item {
    public override int Count { get; set; }
    public override float Weight { get; set; }

    public override string ItemName { get; } = "빈 물통";
    public override bool IsAcquirable { get; } = false;
    public override itemType ItemType { get; } = itemType.EMPTY_BOTTLE;
    public override eventType EventType { get; } = eventType.NONE;

    
    public ItemBottleEmpty(int count = 0, float weight = 0f) {
        this.Count = count;
        this.Weight = weight;
    }
}