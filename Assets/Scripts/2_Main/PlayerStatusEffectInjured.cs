using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerStatusEffectInjured : PlayerStatusEffect {
    public override int Duration { get; set; } = (Random.Range(3, 8) * 500);
    public override string StatusEffectName { get; } = "부상";
    public override statusEffectType StatusEffectType { get; } = statusEffectType.INJURED;

    
    public PlayerStatusEffectInjured() {
        GameInfoView.Instance.StatusEffectUpdate(this.StatusEffectName + " (" + this.Duration + "텀 남음)");
    }
    
    public override int Event() {
        Player.Instance.StatusReduceMultiplier = 2f;
        this.Duration -= 1;
        
        GameInfoView.Instance.StatusEffectUpdate(this.StatusEffectName + " (" + this.Duration + "텀 남음)");
        
        return this.Duration;
    }
}