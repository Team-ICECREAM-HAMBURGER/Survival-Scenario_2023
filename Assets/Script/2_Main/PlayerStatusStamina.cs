using UnityEngine;

public class PlayerStatusStamina : IPlayerStatus {
    public float MaxValue { get; } = 100f;
    public float LimitValue { get; } = 15f;
    public float CurrentValue { get; private set; }
    public string StatusName { get; } = "체력";
    public StatusType StatusType { get; } = StatusType.STAMINA;


    public void StatusUpdate(float value) {
        this.CurrentValue += Mathf.Clamp(value * Player.Instance.StatusReduceMultiplier, 0, 100);
        PlayerInfoView.OnPlayerStatusInfoUpdateEvent(this.StatusType, this.CurrentValue);
    }
}