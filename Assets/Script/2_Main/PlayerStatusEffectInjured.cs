using UnityEngine;

public class PlayerStatusEffectInjured : IPlayerStatusEffect {
    public int DurationTerm { get; set; }
    
    public string StatusEffectName { get; } = "부상";
    public StatusEffectType StatusEffectType { get; } = StatusEffectType.INJURED;
    
    
    public void Event() {
        this.DurationTerm = Random.Range(3, 8) * 500;
        Player.Instance.StatusReduceMultiplier = 2f;
        
        PlayerInfoView.OnStatusEffectGaugeInitEvent(this.DurationTerm);
        
        if (Player.Instance.StatusEffectAdd(this.StatusEffectType, this.DurationTerm)) {
            GameInfo.OnTimeUpdateEvent += DurationTermUpdate;
        }
        
        PlayerInfoView.OnStatusEffectTextUpdateEvent(this.StatusEffectName);
        PlayerInfoView.OnStatusEffectGaugeUpdateEvent(this.DurationTerm);
    }
    
    private void DurationTermUpdate(int value) {
        if (this.DurationTerm > 0) {
            this.DurationTerm -= value;
            PlayerInfoView.OnStatusEffectGaugeUpdateEvent(this.DurationTerm);
            
            return;
        }
        
        Player.Instance.StatusEffectRemove(this.StatusEffectType);
    }
}