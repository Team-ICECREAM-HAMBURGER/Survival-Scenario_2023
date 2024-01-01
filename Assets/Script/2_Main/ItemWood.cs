using Random = UnityEngine.Random;

public class ItemWood : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "나무";
    public bool IsAcquirable { get; } = true;
    public itemType ItemType { get; } = itemType.WOOD;
    public eventType EventType { get; } = eventType.FARMING;

    private readonly int maxValue = 3;
    
    
    public ItemWood(int count = 0, float weight = 25f) {
        this.Count = count;
        this.Weight = weight;
    }

    public bool ItemUse(int value) {
        return true;
    }
    
    public int ItemAcquire() {
        int acquireValue = Random.Range(1, (this.maxValue + 1));

        this.Count += acquireValue;

        return acquireValue;
    }
}