using UnityEngine;

public class ItemTorch : Item {
    public override int Count { get; set; }
    public override float Weight { get; }
    public override bool IsAcquirable { get; } = false;
    public override itemType ItemType { get; } = itemType.TORCH;
    public override eventType EventType { get; } = eventType.NONE;

    private int _durability = 1;
    
    
    public ItemTorch(float weight = 0f, int count = 0) {
        this.Count = count;
        this.Weight = weight;
    }

}