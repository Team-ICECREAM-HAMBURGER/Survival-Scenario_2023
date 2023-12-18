using UnityEngine;

public class ItemHuntingTool : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "사냥 도구";
    public bool IsAcquirable { get; } = false;
    public itemType ItemType { get; } = itemType.HUNTING_TOOL;
    public eventType EventType { get; } = eventType.NONE;

    private int durability = 0;
    private readonly int _durability;
    
    
    public ItemHuntingTool(int count = 0, float weight = 0f) {
        this.Count = count;
        this.Weight = weight;
        this._durability = this.durability;
    }

    public int ItemUse() {
        if (this.durability > 0) {
            this.durability -= 1;
        }
        else {
            this.Count -= 1;
            this.durability = this._durability;
        }

        return this.Count;
    }

    public string ItemAcquire() {
        return "";
    }
}