using UnityEngine;
using UnityEngine.Events;

public class PlayerStatusEffectManager : GameControlSingleton<PlayerStatusEffectManager> {
    [field: SerializeField] public GameControlDictionary.PlayerStatusEffect StatusEffects { get; private set; }

    [HideInInspector] public UnityEvent<int> OnStatusEffect;


    public void Init() {
        this.OnStatusEffect = new();
        
        // TODO: foreach문을 이용한 Init() 방식을 개선; 애초에 개선이 가능한가?
        foreach (var VARIABLE in this.StatusEffects) {
            VARIABLE.Value.Init();
        }
    }
    
    public void StatusEffectAdd(GameControlType.StatusEffect type) {
        this.StatusEffects[type].StatusEffectAdd();
        this.OnStatusEffect.AddListener(this.StatusEffects[type].StatusEffect);
    }
    
    public void StatusEffectInvoke(int value) {
        this.OnStatusEffect.Invoke(value);
    }
    
    public void StatusEffectRemove(GameControlType.StatusEffect type) {
        this.StatusEffects[type].StatusEffectRemove();
        this.OnStatusEffect.RemoveListener(this.StatusEffects[type].StatusEffect);
    }
}