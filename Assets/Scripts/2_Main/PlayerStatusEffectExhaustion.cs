public class PlayerStatusEffectExhaustion : PlayerStatusEffect {
    public override int Duration { get; set; } = 0;
    public override string StatusEffectName { get; } = "탈진";
    public override statusEffectType StatusEffectType { get; } = statusEffectType.EXHAUSTION;

    public PlayerStatusEffectExhaustion() {
        StatusEffect();
    }

    private void StatusEffect() {
        float stamina = Player.Instance.Status[statusType.STAMINA];
        
        Player.Instance.StatusUpdate(-stamina);
    }
}