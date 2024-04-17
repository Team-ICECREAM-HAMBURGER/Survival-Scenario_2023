public interface IPlayerStatusEffect {
    public string StatusEffectName { get; }
    public GameControlType.StatusEffect StatusEffectType { get; }


    public void Event();
}