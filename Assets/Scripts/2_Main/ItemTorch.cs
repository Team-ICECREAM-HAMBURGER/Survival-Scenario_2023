using UnityEngine;

public class ItemTorch : Item {
    public override string ItemName { get; set; }
    public override int Count { get; set; }
    public override float Weight { get; set; }
    
    public override bool IsAcquirable { get; } = false;
    public override itemType ItemType { get; } = itemType.TORCH;
    public override eventType EventType { get; } = eventType.NONE;

    private int _durability = 1;
    
    
    public ItemTorch(string itemName = "횃불", int count = 0, float weight = 0f) {
        this.ItemName = itemName;
        this.Count = count;
        this.Weight = weight;
    }

}