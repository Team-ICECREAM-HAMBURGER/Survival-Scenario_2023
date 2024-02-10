public class PlayerStatusStamina : IPlayerStatus {
    public float MaxValue { get; } = 100f;
    public float LimitValue { get; } = 0f;
    public float CurrentValue { get; private set; }
    
    public string StatusName { get; } = "체력";
    public StatusType StatusType { get; } = StatusType.STAMINA;
    
    
    public void StatusUpdate(float value) {
        this.CurrentValue += value;
    }

    public bool StatusLimitCheck(float value) {
        return this.CurrentValue >= this.LimitValue;
    }
}