public class PlayerStatusEffectExhaustion : IPlayerStatusEffect {
    public int DurationTerm { get; set; } = 0;
    public string StatusEffectName { get; } = "탈진";
    public StatusEffectType StatusEffectType { get; } = StatusEffectType.EXHAUSTION;
    

    public void Event() {
        var stamina = Player.Instance.StatusDictionary[StatusType.STAMINA];
        
        Player.OnPlayerStatusUpdateEvent(-stamina);
    }
}