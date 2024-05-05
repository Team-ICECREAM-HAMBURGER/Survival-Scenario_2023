using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusBodyHeat : MonoBehaviour, IPlayerStatus {
    [SerializeField] private Slider statusGauge;
    
    public float LimitValue { get; } = 25f;
    public float CurrentValue { get; set; }
    public string Name { get; } = "체온";
    public GameControlType.Status Type { get; } = GameControlType.Status.BODY_HEAT;


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