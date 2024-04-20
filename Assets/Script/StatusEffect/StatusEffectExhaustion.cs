using UnityEngine;

public class StatusEffectExhaustion : MonoBehaviour, IStatusEffect {
    public string StatusEffectName { get; set; } = "탈진";
    public GameControlType.StatusEffect StatusEffectType { get; set; } = GameControlType.StatusEffect.EXHAUSTION;
    
    
    public void Event() {
        // Player.Instance.information.status[GameTypeStatus.STAMINA].StatusDecreaseMultiplier = 2f;
        // Player.Instance.StatusEffectAdd(this.GameTypeStatusEffect);
        // GameInformation.OnPlayerStatusEffectIndicatorActiveEvent();
    }

    public void DurationTermUpdate() {
        throw new System.NotImplementedException();
    }
}