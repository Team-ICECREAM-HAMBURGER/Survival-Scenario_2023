public interface IPlayerStatus {
    public string Name { get; }
    public GameControlType.Status Type { get; }
    public float LimitValue { get; }
    public float CurrentValue { get; }
    
    public void Init();
    public void StatusUpdate();
}