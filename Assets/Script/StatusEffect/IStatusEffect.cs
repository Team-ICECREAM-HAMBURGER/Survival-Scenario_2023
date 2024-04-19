public interface IStatusEffect {
    public string StatusEffectName { get; }
    public GameControlType.StatusEffect StatusEffectType { get; }

    public void Event();
    public void DurationTermUpdate();
}