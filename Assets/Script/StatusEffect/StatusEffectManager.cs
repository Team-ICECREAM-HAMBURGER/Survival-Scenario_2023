public class StatusEffectManager : GameControlSingleton<StatusEffectManager> {
    private StatusEffect statusEffect;
    
    
    private void Init() {
        this.statusEffect = new StatusEffect();
    }

    private void Start() {
        Init();
    }
    
    public void Event(StatusEffect effect) {
        this.statusEffect = effect;
        this.statusEffect.Event(effect);
    }
}