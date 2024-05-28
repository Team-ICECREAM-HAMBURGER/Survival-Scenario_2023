public interface IItem {
    public GameControlType.Item Type { get; }
    public string Name { get; }
    public string Content { get; }
    
    public float RandomPercent { get; }
    public float RandomWeight { get; }
    public int RandomMaxValue { get; }

}