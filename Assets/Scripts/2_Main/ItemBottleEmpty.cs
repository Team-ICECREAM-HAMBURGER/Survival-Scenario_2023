public class ItemBottleEmpty : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "빈 물통";
    public bool IsAcquirable { get; } = false;
    public itemType ItemType { get; } = itemType.EMPTY_BOTTLE;
    public eventType EventType { get; } = eventType.NONE;   // TODO: eventType.CRAFT
    
    
    public ItemBottleEmpty(int count = 0, float weight = 0f) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public bool ItemUse() {
        return true;
    }

    public int ItemAcquire() {
        return 0;
    }
}