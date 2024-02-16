public class PlayerStatusStamina : IPlayerStatus {
    public float MaxValue { get; } = 100f;
    public float LimitValue { get; } = 0f;
    public float CurrentValue { get; private set; }
    
    public string StatusName { get; } = "체력";
    public GameTypeStatus GameTypeStatus { get; } = GameTypeStatus.STAMINA;
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