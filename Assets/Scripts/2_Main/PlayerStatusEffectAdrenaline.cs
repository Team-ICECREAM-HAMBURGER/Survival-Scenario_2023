public class PlayerStatusEffectAdrenaline : PlayerStatusEffect {
    public override int Duration { get; set; } = 50;
    public override string StatusEffectName { get; } = "체력 증진";
    public override statusEffectType StatusEffectType { get; } = statusEffectType.ADRENALINE;
    
    
    public PlayerStatusEffectAdrenaline() {
        Event();
    }
}