using UnityEngine;

public class PlayerStatusEffectInjured : IPlayerStatusEffect {
    public string StatusEffectName { get; } = "부상";
    public StatusEffectType StatusEffectType { get; } = StatusEffectType.INJURED;
    public int DurationTerm { get; private set; }
    
    
    public void Event() {
        GameInfoControl.OnTimeUpdateEvent += DurationTermUpdate;

        this.DurationTerm = Random.Range(3, 8) * 500;
        Player.Instance.infoData.status[StatusType.STAMINA].StatusDecreaseMultiplier = 2f;
        
        Player.Instance.StatusEffectAdd(this.StatusEffectType);
        PlayerInfoView.OnPlayerStatusEffectIndicatorActiveEvent();
    }
    
    private void DurationTermUpdate(int value) {
        if (this.DurationTerm > 0) {
            this.DurationTerm -= value;
            
            return;
        }
        
        Player.Instance.StatusEffectRemove(this.StatusEffectType);
        PlayerInfoView.OnPlayerStatusEffectIndicatorUpdateEvent();
    }
}