public class PlayerStatusEffectHypothermia : IPlayerStatusEffect {
    public int DurationTerm { get; set; }
    public string StatusEffectName { get; }
    public statusEffectType StatusEffectType { get; }
    
    public void Event() {
    }
}