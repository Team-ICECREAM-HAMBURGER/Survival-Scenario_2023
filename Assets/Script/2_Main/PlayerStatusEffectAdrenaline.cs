public class PlayerStatusEffectAdrenaline : IPlayerStatusEffect {
    public int DurationTerm { get; set; }
    
    public string StatusEffectName { get; } = "체력 증진";
    public StatusEffectType StatusEffectType { get; } = StatusEffectType.ADRENALINE;

    
    public void Event() {
    }
}