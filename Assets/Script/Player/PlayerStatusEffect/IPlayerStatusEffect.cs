public interface IPlayerStatusEffect {
    public string Name { get; }
    public GameControlType.StatusEffect Type { get; }
    public int Term { get; }


    public void Init();
    public void StatusEffectInvoke(int value = 0);
}