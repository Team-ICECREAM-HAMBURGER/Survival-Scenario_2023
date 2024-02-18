public class PlayerStatusHydration : IPlayerStatus {
    public float MaxValue { get; } = 100f;
    public float LimitValue { get; } = 20f;

    public float CurrentValue { get; set; }
    // public float CurrentValue { get; private set; }
    
    public string StatusName { get; } = "수분";
    public GameTypeStatus GameTypeStatus { get; } = GameTypeStatus.HYDRATION;
    public float StatusDecreaseMultiplier { get; set; }


    public void StatusIncrease(float value) {
        this.CurrentValue += value;
    }

    public void StatusDecrease(float value) {
        this.CurrentValue -= value * this.StatusDecreaseMultiplier;
    }
    
    public bool StatusLimitCheck(float value) {
        return this.CurrentValue >= this.LimitValue;
    }
}