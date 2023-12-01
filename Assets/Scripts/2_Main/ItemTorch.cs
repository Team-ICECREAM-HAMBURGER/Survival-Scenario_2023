using UnityEngine;

public class ItemTorch : Item {
    public override int Count { get; set; }
    public override float Weight { get; set; }

    public override string ItemName { get; } = "횃불";
    public override bool IsAcquirable { get; } = false;
    public override itemType ItemType { get; } = itemType.TORCH;
    public override eventType EventType { get; } = eventType.NONE;

    private int durability = 1;
    
    
    public ItemTorch(int count = 0, float weight = 0f) {
        this.Count = count;
        this.Weight = weight;
    }

}