using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusCalories : MonoBehaviour, IPlayerStatus {
    [SerializeField] private Slider statusGauge;
    
    public float LimitValue { get; } = 15f;
    public float CurrentValue { get; set; }
    
    public string Name { get; } = "칼로리";
    public GameControlType.Status Type { get; } = GameControlType.Status.CALORIES;
    
    
    public void Invoke() {
        this.CurrentValue = Player.Instance.Status[this.Type];
        
        if (this.CurrentValue <= this.LimitValue) {
            Player.Instance.StatusEffectAdd(GameControlType.StatusEffect.HUNGER);
        }
        
        UpdateView();
    }

    public void UpdateView() {
        this.statusGauge.value = this.CurrentValue;
    }

    private void DeathByStarvation() {
        var title = "아사했습니다.";
        var content = "굶주림을 이기지 못했습니다. 서서히 눈이 감겨옵니다...";

        GameEventGameOver.OnGameOverBadEnding(title, content);
    }
}