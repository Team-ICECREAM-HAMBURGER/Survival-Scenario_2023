public interface IItem {
    public GameTypeItem ItemType { get; }
    public string ItemName { get; }
    
    public void Init(float value);
}