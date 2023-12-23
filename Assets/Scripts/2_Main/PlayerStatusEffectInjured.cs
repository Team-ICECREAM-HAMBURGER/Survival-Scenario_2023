using UnityEngine;

public class PlayerStatusEffectInjured : IPlayerStatusEffect {
    public int DurationTerm { get; set; }
    public string StatusEffectName { get; } = "부상";
    public statusEffectType StatusEffectType { get; } = statusEffectType.INJURED;


    public void Event() {
        this.DurationTerm = Random.Range(3, 8) * 500;
        Player.Instance.StatusReduceMultiplier = 2f;
        Player.Instance.StatusEffectAdd(this.StatusEffectType, this.DurationTerm, this.StatusEffectName);
    }
    
    // TODO : 시간이 흐를 때마다 DurationTerm -= 1
}