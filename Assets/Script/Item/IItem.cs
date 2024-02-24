public interface IItem {
    public GameTypeItem ItemType { get; }
    public string ItemName { get; }
    public int ItemQuantity { get; set; }
}