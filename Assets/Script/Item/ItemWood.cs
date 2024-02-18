using Random = UnityEngine.Random;

public class ItemWood : IItem {
    public int Count { get; set; }
    public float Weight { get; set; }

    public string ItemName { get; } = "나무";
    public bool IsAcquirable { get; } = true;
    public GameTypeItem GameTypeItem { get; } = GameTypeItem.WOOD;
    public GameTypeBehaviourEvent EventType { get; }

    private readonly int maxValue = 3;
    
    
    public ItemWood(int count = 100, float weight = 25f) {
        this.Count = count;
        this.Weight = weight;
    }

    public int ItemUse(int value) {
        this.Count -= value;
        
        return value;
    }
    
    public int ItemAcquire() {
        var acquireValue = Random.Range(1, (this.maxValue + 1));

        this.Count += acquireValue;

        return acquireValue;
    }
}