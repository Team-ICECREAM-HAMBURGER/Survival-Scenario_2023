public interface IItem {
    int Count { get; set; }
    float Weight { get; set; }
    bool IsAcquirable { get; set; }
    itemType ItemType { get; set; }
    
    void ItemFarming();
}