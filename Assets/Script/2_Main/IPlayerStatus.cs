public interface IPlayerStatus {
    public float MaxValue { get; }
    public float LimitValue { get; }
    public float CurrentValue { get; }
    public string StatusName { get; }
    public StatusType StatusType { get; }
    public float StatusDecreaseMultiplier { get; set; }
    
    public void StatusIncrease(float value);
}