using UnityEngine;

public class PlayerStatusEffectDehydration : IPlayerStatusEffect {
    public string StatusEffectName { get; } = "탈수";
    public StatusEffectType StatusEffectType { get; } = StatusEffectType.DEHYDRATION;
    
    
    public void Event() {
        Player.Instance.infoData.status[StatusType.HYDRATION].StatusDecreaseMultiplier = 2f;
        
        Player.Instance.StatusEffectAdd(this.StatusEffectType);
        PlayerInfoView.OnPlayerStatusEffectIndicatorActiveEvent();
    }
}