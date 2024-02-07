public class PlayerStatusEffectAdrenaline : IPlayerStatusEffect {
    public string StatusEffectName { get; } = "체력 증진";
    public StatusEffectType StatusEffectType { get; } = StatusEffectType.ADRENALINE;

    
    public void Event() {
        /*
         * Player.Instance.StatusUpdate()
            * Player.Instance.StatusCheck()
                * true
                    * IPlayerStatusEffect.Event()
                * false
                    * Pass;
         */
    }
}