public interface IStatusEffect {
    public string Name { get; }
    public GameControlType.StatusEffect Type { get; }
    public int Term { get; }


    public void Init();
    public void Active();
    public void Invoke();
}