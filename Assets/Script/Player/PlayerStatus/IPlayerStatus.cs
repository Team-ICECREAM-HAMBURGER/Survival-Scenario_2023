public interface IPlayerStatus {
    public float MaxValue { get; }
    public float LimitValue { get; }
    public float CurrentValue { get; }
    
    public string StatusName { get; }
    public GameTypeStatus GameTypeStatus { get; }
    public float StatusDecreaseMultiplier { get; set; }
    
    
    public void StatusIncrease(float value);
    public void StatusDecrease(float value);
    public bool StatusLimitCheck(float value);
}