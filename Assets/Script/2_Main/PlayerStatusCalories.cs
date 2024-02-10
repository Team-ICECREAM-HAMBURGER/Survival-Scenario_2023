using UnityEngine;

public class PlayerStatusCalories : IPlayerStatus {
    public float MaxValue { get; } = 100f;
    public float LimitValue { get; } = 15f;
    
    public string StatusName { get; } = "체력";
    public StatusType StatusType { get; } = StatusType.STAMINA;
    
    private float statusCurrentValue;
    
    
    public void StatusUpdate(float value) {
        this.statusCurrentValue += Mathf.Clamp(value * Player.Instance.StatusReduceMultiplier, 0, 100);
        PlayerInfoView.OnPlayerStatusInfoUpdateEvent(this.StatusType, this.statusCurrentValue);
        
        StatusCheck();
    }

    public void StatusCheck() {
        if (this.statusCurrentValue > this.LimitValue) {
            return;
        }

        Player.Instance.StatusEffectAdd(StatusEffectType.EXHAUSTION);
    }
}