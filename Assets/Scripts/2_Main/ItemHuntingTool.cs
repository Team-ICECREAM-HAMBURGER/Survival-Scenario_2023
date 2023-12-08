using UnityEngine;

public class ItemHuntingTool : Item {
    public override int Count { get; set; }
    public override float Weight { get; set; }

    public override string ItemName { get; } = "사냥 도구";
    public override bool IsAcquirable { get; } = false;
    public override itemType ItemType { get; } = itemType.HUNTING_TOOL;
    public override eventType EventType { get; } = eventType.NONE;

    private int durability = 0;
    private readonly int _durability;
    
    
    public ItemHuntingTool(int count = 1, float weight = 0f) {
        this.Count = count;
        this.Weight = weight;
        this._durability = this.durability;
    }

    public override int ItemUse() {
        if (this.durability > 0) {
            this.durability -= 1;
        }
        else {
            this.Count -= 1;
            this.durability = this._durability;
        }

        return this.Count;
    }
}