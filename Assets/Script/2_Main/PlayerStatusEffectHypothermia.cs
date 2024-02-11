using UnityEngine;

public class PlayerStatusEffectHypothermia : IPlayerStatusEffect {
    public string StatusEffectName { get; } = "저체온증";
    public StatusEffectType StatusEffectType { get; } = StatusEffectType.HYPOTHERMIA;
    
    
    public void Event() {
        Player.Instance.infoData.status[StatusType.BODY_HEAT].StatusDecreaseMultiplier = 2f;
        
        Player.Instance.StatusEffectAdd(this.StatusEffectType);
        PlayerInfoView.OnPlayerStatusEffectIndicatorActiveEvent();
    }
}