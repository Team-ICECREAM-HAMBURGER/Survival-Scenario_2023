using System.Collections.Generic;

public class PlayerStatusEffectManager : GameControlSingleton<PlayerStatusEffectManager> {
    public Dictionary<string, IPlayerStatusEffect> StatusEffects { get; private set; }
    

    private void Init() {
        this.StatusEffects = new();
        
        foreach (var VARIABLE in GetComponents<IPlayerStatusEffect>()) {
            this.StatusEffects[VARIABLE.Name] = VARIABLE;
        }
    }

    private void Awake() {
        Init();
    }
}