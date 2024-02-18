public interface IItem {
    public int Count { get; set; }
    public float Weight { get; set; }
    
    public string ItemName { get; }
    public GameTypeItem GameTypeItem { get; }
    public GameTypeBehaviourEvent EventType { get; }
    
    
    public int ItemUse(int value);
    public int ItemAcquire();
}