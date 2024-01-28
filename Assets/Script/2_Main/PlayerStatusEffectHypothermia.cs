public class PlayerStatusEffectHypothermia : IPlayerStatusEffect {
    public int DurationTerm { get; set; }
    public string StatusEffectName { get; }
    public StatusEffectType StatusEffectType { get; }
    
    public void Event() {
    }
}