using UnityEngine;

public class PlayerPlayerStatusEffectDehydration : IPlayerStatusEffect {
    public string StatusEffectName { get; } = "탈수";
    public GameTypeStatusEffect GameTypeStatusEffect { get; } = GameTypeStatusEffect.DEHYDRATION;
    
    
    public void Event() {
        Player.Instance.information.status[GameTypeStatus.HYDRATION].StatusDecreaseMultiplier = 2f;
        Player.Instance.StatusEffectAdd(this.GameTypeStatusEffect);
        GameInformation.OnPlayerStatusEffectIndicatorActiveEvent();
    }
}