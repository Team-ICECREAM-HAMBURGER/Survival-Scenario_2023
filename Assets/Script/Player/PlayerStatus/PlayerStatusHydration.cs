using UnityEngine;

public class PlayerStatusHydration : MonoBehaviour, IPlayerStatus {
    public float LimitValue { get; } = 30f;
    public float CurrentValue { get; set; }
    
    public string Name { get; } = "수분";
    public GameControlType.Status Type { get; } = GameControlType.Status.HYDRATION;


    public void Invoke(float value) {
        this.CurrentValue = value;

        if (Player.Instance.Status[GameControlType.Status.HYDRATION] <= this.LimitValue) {
            Player.Instance.StatusEffectMap[GameControlType.StatusEffect.DEHYDRATION].Active();
        }
    }
}