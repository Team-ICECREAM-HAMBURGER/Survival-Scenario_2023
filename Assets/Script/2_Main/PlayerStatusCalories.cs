public class PlayerStatusCalories : IPlayerStatus {
    public float MaxValue { get; } = 100f;
    public float LimitValue { get; } = 15f;
    public float CurrentValue { get; private set; }
    
    public string StatusName { get; } = "칼로리";
    public StatusType StatusType { get; } = StatusType.CALORIES;
    public float StatusDecreaseMultiplier { get; set; }


    public void StatusIncrease(float value) {
        this.CurrentValue += value;
    }

    public bool StatusLimitCheck(float value) {
        return this.CurrentValue >= this.LimitValue;
    }
}