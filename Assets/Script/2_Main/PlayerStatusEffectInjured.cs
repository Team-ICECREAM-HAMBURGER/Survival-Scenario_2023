using UnityEngine;

public class PlayerStatusEffectInjured : IPlayerStatusEffect {
    public int DurationTerm { get; set; }
    
    public string StatusEffectName { get; } = "부상";
    public statusEffectType StatusEffectType { get; } = statusEffectType.INJURED;

    
    public void Event() {
        this.DurationTerm = Random.Range(3, 8) * 500;
        Player.Instance.StatusEffectAdd(this.StatusEffectType, this.DurationTerm);
        PlayerInfoView.OnStatusEffectAddEvent(this.StatusEffectName);
    }
    
    private void DurationTermUpdate(int value) {
        this.DurationTerm -= value;
    }
}