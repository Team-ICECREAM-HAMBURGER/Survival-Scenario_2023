public class PlayerStatusEffectHealing : PlayerStatusEffect {
    public override int Duration { get; set; }
    public override string StatusEffectName { get; }
    public override statusEffectType StatusEffectType { get; }
}