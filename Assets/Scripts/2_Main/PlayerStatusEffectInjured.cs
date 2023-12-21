using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerStatusEffectInjured : IPlayerStatusEffect {
    public int Duration { get; set; } = 2;
    public string StatusEffectName { get; } = "부상";
    public statusEffectType StatusEffectType { get; } = statusEffectType.INJURED;

    
    public void Event() {
        if (this.Duration <= 0) {
            Player.Instance.StatusReduceMultiplier = 1f;
            Player.Instance.StatusEffectRemove(this.StatusEffectType);
            
            return;
        }
        
        Player.Instance.StatusReduceMultiplier = 2f;
        Player.Instance.StatusEffectAdd(this.StatusEffectType, this.Duration, this.StatusEffectName);
    }
}