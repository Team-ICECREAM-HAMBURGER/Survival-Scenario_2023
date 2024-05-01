using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : GameControlSingleton<StatusEffectManager> {
    public Dictionary<string, IStatusEffect> StatusEffects { get; private set; }
    

    private void Init() {
        this.StatusEffects = new();
        
        foreach (var VARIABLE in GetComponents<IStatusEffect>()) {
            this.StatusEffects[VARIABLE.Name] = VARIABLE;
            this.StatusEffects[VARIABLE.Name].Term = Player.Instance.StatusEffect[VARIABLE.Name];
            Player.OnStatusEffectInvoke += this.StatusEffects[VARIABLE.Name].Invoke;
        }
    }

    private void Start() {
        Init();
    }
}