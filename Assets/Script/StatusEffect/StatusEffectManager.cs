public class StatusEffectManager : GameControlSingleton<StatusEffectManager> {
    private StatusEffect statusEffect;
    
    public delegate void StatusEffectInvokeEventHandler(int value);
    public static StatusEffectInvokeEventHandler OnStatusEffectInvoke;

    
    public void Event(StatusEffect effect) {
        this.statusEffect = effect;
        this.statusEffect.Event(effect);
    }
}