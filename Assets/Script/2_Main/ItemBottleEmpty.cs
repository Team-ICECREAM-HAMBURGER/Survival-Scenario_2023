public class ItemBottleEmpty : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "빈 물통";
    public bool IsAcquirable { get; } = false;
    public ItemType ItemType { get; } = ItemType.EMPTY_BOTTLE;
    public EventType EventType { get; } = EventType.NONE;   // TODO: eventType.CRAFT
    
    
    public ItemBottleEmpty(int count = 0, float weight = 0f) {
        this.Count = count;
        this.Weight = weight;
    }
    
    public int ItemUse(int value) {
        this.Count -= value;
        
        return value;
    }

    public int ItemAcquire() {
        return 0;
    }
}