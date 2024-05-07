using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusHydration : MonoBehaviour, IPlayerStatus {
    [SerializeField] private Slider statusGauge;
    
    public float LimitValue { get; } = 30f;
    public float CurrentValue { get; set; }
    
    public string Name { get; } = "수분";
    public GameControlType.Status Type { get; } = GameControlType.Status.HYDRATION;

    
    public void Invoke() {
        this.CurrentValue = Player.Instance.Status[this.Type];
        UpdateView();
    }

    public void UpdateView() {
        this.statusGauge.value = this.CurrentValue;
    }
    
    private void DeathByDehydration() {
        var title = "갈사했습니다.";
        var content = "목이 타들어갑니다. 점점 시야가 흐려집니다...";

        GameEventGameOver.OnGameOverBadEnding(title, content);
    }
}