public interface IPlayerStatus {
    public float LimitValue { get; }
    public float CurrentValue { get; }
    public string Name { get; }
    public GameControlType.Status Type { get; }

    public void Init();
    public void StatusUpdate();
}