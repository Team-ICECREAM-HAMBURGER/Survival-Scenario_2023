using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusStamina : MonoBehaviour, IPlayerStatus {
    [SerializeField] private Slider statusGauge;
    
    public float LimitValue { get; } = 30f;
    public float CurrentValue { get; set; }
    
    public string Name { get; } = "체력";
    public GameControlType.Status Type { get; } = GameControlType.Status.STAMINA;

    
    public void Invoke() {
        this.CurrentValue = Player.Instance.Status[this.Type];
        
        if (this.CurrentValue <= this.LimitValue) {
            Player.Instance.StatusEffectAdd(GameControlType.StatusEffect.EXHAUSTION);
        }
        else {
            Player.Instance.StatusEffectRemove(GameControlType.StatusEffect.EXHAUSTION);
        }
        
        UpdateView();
    }

    public void UpdateView() {
        this.statusGauge.value = this.CurrentValue;
    }
}