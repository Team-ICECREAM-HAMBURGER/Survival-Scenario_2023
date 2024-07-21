using UnityEngine;
using UnityEngine.Events;

public class PlayerStatusEffectManager : GameControlSingleton<PlayerStatusEffectManager> {
    [field: SerializeField] public GameControlDictionary.PlayerStatusEffect StatusEffects { get; private set; }

    private UnityEvent OnStatusEffect;


    public void Init() {
        this.OnStatusEffect = new();

        foreach (var VARIABLE in this.StatusEffects) {
            VARIABLE.Value.Init();
        }
    }
    
    public void StatusEffectAdd(GameControlType.StatusEffect type) {
        this.StatusEffects[type].StatusEffectAdd();
        this.OnStatusEffect.AddListener(this.StatusEffects[type].StatusEffect);
    }
    
    public void StatusEffectInvoke() {
        this.OnStatusEffect.Invoke();
    }
    
    public void StatusEffectRemove(GameControlType.StatusEffect type) {
        this.StatusEffects[type].StatusEffectRemove();
        this.OnStatusEffect.RemoveListener(this.StatusEffects[type].StatusEffect);
    }
}