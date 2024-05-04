using UnityEngine;

public class PlayerStatusStamina : MonoBehaviour, IPlayerStatus {
    public float LimitValue { get; } = 0f;
    public float CurrentValue { get; set; }
    
    public string Name { get; } = "체력";
    public GameControlType.Status Type { get; } = GameControlType.Status.STAMINA;


    public void Invoke(float value) {
        this.CurrentValue = value;
    }
}