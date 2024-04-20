using UnityEngine;

public class StatusEffectDehydration : MonoBehaviour, IStatusEffect {
    public string StatusEffectName { get; set; } = "탈수";
    public GameControlType.StatusEffect StatusEffectType { get; set; } = GameControlType.StatusEffect.DEHYDRATION;
    
    
    public void Event() {
        // Player.Instance.information.status[GameTypeStatus.HYDRATION].StatusDecreaseMultiplier = 2f;
        // Player.Instance.StatusEffectAdd(this.GameTypeStatusEffect);
        // GameInformation.OnPlayerStatusEffectIndicatorActiveEvent();
    }

    public void DurationTermUpdate() {
        throw new System.NotImplementedException();
    }
}