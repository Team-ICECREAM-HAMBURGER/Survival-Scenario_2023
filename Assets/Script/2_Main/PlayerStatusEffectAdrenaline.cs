public class PlayerStatusEffectAdrenaline : IPlayerStatusEffect {
    public int DurationTerm { get; set; }
    
    public string StatusEffectName { get; } = "체력 증진";
    public statusEffectType StatusEffectType { get; } = statusEffectType.ADRENALINE;

    
    public void Event() {
    }
}