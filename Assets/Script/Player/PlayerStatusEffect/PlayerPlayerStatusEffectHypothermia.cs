using UnityEngine;

public class PlayerPlayerStatusEffectHypothermia : IPlayerStatusEffect {
    public string StatusEffectName { get; } = "저체온증";
    public GameTypeStatusEffect GameTypeStatusEffect { get; } = GameTypeStatusEffect.HYPOTHERMIA;
    
    
    public void Event() {
        Player.Instance.information.status[GameTypeStatus.BODY_HEAT].StatusDecreaseMultiplier = 2f;
        Player.Instance.StatusEffectAdd(this.GameTypeStatusEffect);
        GameInformation.OnPlayerStatusEffectIndicatorActiveEvent();
    }
}