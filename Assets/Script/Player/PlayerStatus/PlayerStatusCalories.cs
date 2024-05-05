using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusCalories : MonoBehaviour, IPlayerStatus {
    [SerializeField] private Slider statusGauge;
    
    public float LimitValue { get; } = 15f;
    public float CurrentValue { get; set; }
    
    public string Name { get; } = "칼로리";
    public GameControlType.Status Type { get; } = GameControlType.Status.CALORIES;


    public void Init(float value) {
        this.CurrentValue = value;
        UpdateView();
    }
    
    public void Invoke(float value) {
        this.CurrentValue = value;
        UpdateView();
    }
    
    public void UpdateView() {
        this.statusGauge.value = Mathf.Clamp(this.CurrentValue, 0f, 100f);
    }
}