public interface IPlayerStatus {
    public float LimitValue { get; }
    public float CurrentValue { get; set; }
    public string Name { get; }
    public GameControlType.Status Type { get; }

    public void Init(float value);
    public void Invoke(float value);
    public void UpdateView();
}