using UnityEngine;

public class PlayerStatusEffectExhaustion : IPlayerStatusEffect {
    public string StatusEffectName { get; } = "탈진";
    public GameControlType.StatusEffect StatusEffectType { get; } = GameControlType.StatusEffect.EXHAUSTION;
    
    
    public void Event() {
        // Player.Instance.information.status[GameTypeStatus.STAMINA].StatusDecreaseMultiplier = 2f;
        // Player.Instance.StatusEffectAdd(this.GameTypeStatusEffect);
        // GameInformation.OnPlayerStatusEffectIndicatorActiveEvent();
    }
}