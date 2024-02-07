public interface IPlayerStatusEffect {
    public string StatusEffectName { get; }
    public StatusEffectType StatusEffectType { get; }


    public void Event();
}