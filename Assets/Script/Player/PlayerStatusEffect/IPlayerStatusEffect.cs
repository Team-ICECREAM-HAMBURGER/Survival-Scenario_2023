public interface IPlayerStatusEffect {
    public string StatusEffectName { get; }
    public GameTypeStatusEffect GameTypeStatusEffect { get; }


    public void Event();
}