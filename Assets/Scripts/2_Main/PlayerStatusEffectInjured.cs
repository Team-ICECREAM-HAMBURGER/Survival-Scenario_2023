using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerStatusEffectInjured : IPlayerStatusEffect {
    public int DurationTerm { get; set; }
    public string StatusEffectName { get; } = "부상";
    public statusEffectType StatusEffectType { get; } = statusEffectType.INJURED;

    
    public void Event() {
        this.DurationTerm = Random.Range(3, 8) * 500;
        
        if (this.DurationTerm <= 0) {
            Player.Instance.StatusReduceMultiplier = 1f;
            Player.Instance.StatusEffectRemove(this.StatusEffectType);
            
            return;
        }
        
        Player.Instance.StatusReduceMultiplier = 2f;
        Player.Instance.StatusEffectAdd(this.StatusEffectType, this.DurationTerm, this.StatusEffectName);
    }
}