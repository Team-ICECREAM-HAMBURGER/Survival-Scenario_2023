using System;
using UnityEngine;

public class PlayerStatusStamina : MonoBehaviour, IPlayerStatus {   // Presenter
    public float LimitValue { get; } = 30f;
    public float CurrentValue { get; private set; }
    public string Name { get; } = "체력";
    public GameControlType.Status Type { get; } = GameControlType.Status.STAMINA;
    

    public void Init() {
        this.CurrentValue = Player.Instance.Status[this.Type];
        PlayerInformation.OnStatusGaugeUpdate.Invoke(this.Type, this.CurrentValue);
    }

    public void StatusUpdate() {    // onStatusUpdate()
        this.CurrentValue = Player.Instance.Status[this.Type];
        PlayerInformation.OnStatusGaugeUpdate.Invoke(this.Type, this.CurrentValue);
        
        if (this.CurrentValue <= this.LimitValue) {
            PlayerStatusEffectExhaustion.OnStatusEffectAdd.Invoke();
        }
        else if (Player.Instance.StatusEffect.ContainsKey(GameControlType.StatusEffect.EXHAUSTION)) {
            PlayerStatusEffectExhaustion.OnStatusEffectRemove.Invoke();
        }
    }
}