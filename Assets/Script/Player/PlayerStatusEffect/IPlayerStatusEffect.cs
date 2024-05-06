public interface IPlayerStatusEffect {
    public string Name { get; }
    public GameControlType.StatusEffect Type { get; }
    public int Term { get; set; }

    
    public void Active();
    public void Invoke(int value = 0);
}