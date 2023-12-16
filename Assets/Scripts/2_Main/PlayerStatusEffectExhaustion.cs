public class PlayerStatusEffectExhaustion : IPlayerStatusEffect {
    public int Duration { get; set; } = 0;
    public string StatusEffectName { get; } = "탈진";
    public statusEffectType StatusEffectType { get; } = statusEffectType.EXHAUSTION;
    

    public void Event() {
        float stamina = Player.Instance.Status[statusType.STAMINA];
        
        Player.Instance.StatusUpdate(-stamina);
    }
}