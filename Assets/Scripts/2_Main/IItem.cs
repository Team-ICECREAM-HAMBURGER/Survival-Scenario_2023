public interface IItem {
    int Count { get; set; }
    float Weight { get; }
    bool IsAcquirable { get; }
    itemType ItemType { get; }
    
    void ItemFarming();
}