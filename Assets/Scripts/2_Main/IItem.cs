public interface IItem {
    int Count { get; set; }
    float Weight { get; set; }
    bool IsAcquirable { get; set; }
    ItemType ItemType { get; set; }
    
    void ItemFarming();
}