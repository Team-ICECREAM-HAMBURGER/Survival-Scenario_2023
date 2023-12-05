using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerStatusEffectInjured : PlayerStatusEffect {
    public override int Duration { get; set; } = (Random.Range(3, 8) * 500) + 1;
    public override string StatusEffectName { get; } = "부상";
    public override statusEffectType StatusEffectType { get; } = statusEffectType.INJURED;


    public PlayerStatusEffectInjured() {
        StatusEffect();
    }
    
    public override void StatusEffect() {
        Player.Instance.StatusReduceMultiplier = 1.5f;
        this.Duration -= 1;
    }
}