using UnityEngine;

public class PlayerStatusEffectExhaustion : IPlayerStatusEffect {
    public string StatusEffectName { get; } = "탈진";
    public StatusEffectType StatusEffectType { get; } = StatusEffectType.EXHAUSTION;
    
    
    public void Event() {
        Player.Instance.infoData.status[StatusType.STAMINA].StatusDecreaseMultiplier = 2f;
        
        Player.Instance.StatusEffectAdd(this.StatusEffectType);
        PlayerInfoView.OnPlayerStatusEffectIndicatorActiveEvent();
    }
}