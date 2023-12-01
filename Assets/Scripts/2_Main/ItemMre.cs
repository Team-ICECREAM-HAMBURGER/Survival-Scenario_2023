using UnityEngine;

public class ItemMre : Item {
    public override int Count { get; set; }
    public override float Weight { get; set; }

    public override string ItemName { get; } = "비상식량";
    public override bool IsAcquirable { get; } = false;
    public override itemType ItemType { get; } = itemType.MRE;
    public override eventType EventType { get; } = eventType.NONE;


    public ItemMre(int count = 0, float weight = 0f) {
        this.Count = count;
        this.Weight = weight;
    }
}
