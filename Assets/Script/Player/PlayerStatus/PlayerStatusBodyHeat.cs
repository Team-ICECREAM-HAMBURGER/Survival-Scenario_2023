using UnityEngine;

public class PlayerStatusBodyHeat : MonoBehaviour, IPlayerStatus {
    public float LimitValue { get; } = 25f;
    public float CurrentValue { get; set; }
    public string Name { get; } = "체온";
    public GameControlType.Status Type { get; } = GameControlType.Status.BODY_HEAT;


    public void Invoke(float value) {
        this.CurrentValue = value;
    }
}