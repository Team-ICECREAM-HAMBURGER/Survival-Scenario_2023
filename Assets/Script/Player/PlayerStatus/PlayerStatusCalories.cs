using UnityEngine;

public class PlayerStatusCalories : MonoBehaviour, IPlayerStatus {
    public float LimitValue { get; } = 15f;
    public float CurrentValue { get; set; }
    
    public string Name { get; } = "칼로리";
    public GameControlType.Status Type { get; } = GameControlType.Status.CALORIES;


    public void Invoke(float value) {
        this.CurrentValue = value;
    }
}