using UnityEngine;

public class PlayerStatusEffectHypothermia : IPlayerStatusEffect {
    public string StatusEffectName { get; } = "저체온증";
    public GameControlType.StatusEffect StatusEffectType { get; } = GameControlType.StatusEffect.HYPOTHERMIA;
    
    
    public void Event() {
        // Player.Instance.information.status[GameTypeStatus.BODY_HEAT].StatusDecreaseMultiplier = 2f;
        // Player.Instance.StatusEffectAdd(this.GameTypeStatusEffect);
        // GameInformation.OnPlayerStatusEffectIndicatorActiveEvent();
    }
}