using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusHydration : MonoBehaviour, IPlayerStatus {
    [SerializeField] private Slider statusGauge;
    
    public float LimitValue { get; } = 30f;
    public float CurrentValue { get; set; }
    
    public string Name { get; } = "수분";
    public GameControlType.Status Type { get; } = GameControlType.Status.HYDRATION;


    public void Init(float value) {
        this.CurrentValue = value;
        UpdateView();
    }
    
    public void Invoke(float value) {
        this.CurrentValue = value;

        if (this.CurrentValue <= 0f) {  // 갈사
            DeathByDehydration();
            return;
        }
        
        if (this.CurrentValue <= this.LimitValue) {
            Player.Instance.StatusEffectMap[GameControlType.StatusEffect.DEHYDRATION].Active();
        }
        
        UpdateView();
    }
    
    public void UpdateView() {
        this.statusGauge.value = Mathf.Clamp(this.CurrentValue, 0f, 100f);
    }
    
    private void DeathByDehydration() {
        var title = "갈사했습니다.";
        var content = "목이 타들어갑니다. 점점 시야가 흐려집니다...";

        GameEventGameOver.OnGameOverBadEnding(title, content);
    }
}