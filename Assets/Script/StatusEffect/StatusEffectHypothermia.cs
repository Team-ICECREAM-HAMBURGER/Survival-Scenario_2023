using UnityEngine;

public class StatusEffectHypothermia : MonoBehaviour, IStatusEffect {
    public string StatusEffectName { get; set; } = "저체온증";
    public GameControlType.StatusEffect StatusEffectType { get; set; } = GameControlType.StatusEffect.HYPOTHERMIA;
    
    
    public void Event() {
        // Player.Instance.information.status[GameTypeStatus.BODY_HEAT].StatusDecreaseMultiplier = 2f;
        // Player.Instance.StatusEffectAdd(this.GameTypeStatusEffect);
        // GameInformation.OnPlayerStatusEffectIndicatorActiveEvent();
    }

    public void DurationTermUpdate() {
        throw new System.NotImplementedException();
    }
}