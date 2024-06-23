public interface IPlayerStatusEffect {
    public string Name { get; }
    public int Term { get; }
    public GameControlType.StatusEffect Type { get; }
    public GameControlDictionary.RequireStatus StatusReducePercents { get; }

    public void Init();
    public void StatusEffect(int value);
}