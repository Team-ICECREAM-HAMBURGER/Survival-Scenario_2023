public interface IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    
    public string ItemName { get; }
    public bool IsAcquirable { get; }
    public itemType ItemType { get; }
    public eventType EventType { get; }
    
    
    public int ItemUse();
    public string ItemAcquire();
}