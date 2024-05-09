using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusStamina : MonoBehaviour, IPlayerStatus {
    public float LimitValue { get; } = 30f;
    public float CurrentValue { get; private set; }
    
    public string Name { get; } = "체력";
    public GameControlType.Status Type { get; } = GameControlType.Status.STAMINA;


    public void Init() {
        this.CurrentValue = Player.Instance.Status[this.Type];
    }

    public void StatusUpdate() {    // onStatusUpdate()
        this.CurrentValue = Player.Instance.Status[this.Type];
        
        if (this.CurrentValue <= this.LimitValue) {
            Player.Instance.StatusEffectAdd(GameControlType.StatusEffect.EXHAUSTION);
        }
        
        //PlayerInformationViewer..Invoke();
    }
}