using UnityEngine;

public class PlayerStatusEffectInjured : IPlayerStatusEffect {
    public int DurationTerm { get; set; }
    
    public string StatusEffectName { get; } = "부상";
    public statusEffectType StatusEffectType { get; } = statusEffectType.INJURED;


    public void Event() {
        this.DurationTerm = Random.Range(3, 8) * 500;
        Player.Instance.StatusReduceMultiplier = 2f;

        if (Player.Instance.StatusEffectAdd(this.StatusEffectType, this.DurationTerm)) {
            GameInfo.OnTimeUpdateEvent += DurationTermUpdate;
        }
        
        PlayerInfoView.OnStatusEffectTextUpdateEvent(this.StatusEffectName);
        PlayerInfoView.OnStatusEffectGaugeUpdateEvent(100f);
    }
    
    private void DurationTermUpdate(int value) {
        if (this.DurationTerm > 0) {
            this.DurationTerm -= value;
            return;
        }
        
        Player.Instance.StatusEffectUpdate(this.StatusEffectType);
    }
}