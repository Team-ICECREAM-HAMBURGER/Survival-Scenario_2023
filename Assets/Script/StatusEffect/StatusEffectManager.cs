using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : GameControlSingleton<StatusEffectManager> {
    public Dictionary<string, IStatusEffect> StatusEffects { get; private set; }
    

    private void Init() {
        this.StatusEffects = new();
        
        foreach (var VARIABLE in GetComponents<IStatusEffect>()) {
            this.StatusEffects[VARIABLE.Name] = VARIABLE;
        }
    }

    private void Start() {
        Init();
    }
}