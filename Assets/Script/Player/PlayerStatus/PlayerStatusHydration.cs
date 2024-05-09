using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusHydration : MonoBehaviour, IPlayerStatus {
    public float LimitValue { get; } = 30f;
    public float CurrentValue { get; set; }
    
    public string Name { get; } = "수분";
    public GameControlType.Status Type { get; } = GameControlType.Status.HYDRATION;


    public void Init() {
        throw new System.NotImplementedException();
    }

    public void StatusUpdate() {
        this.CurrentValue = Player.Instance.Status[this.Type];

        if (this.CurrentValue <= 0) {
            DeathByDehydration();
        }
        else if (this.CurrentValue <= this.LimitValue) {
            Player.Instance.StatusEffectAdd(GameControlType.StatusEffect.DEHYDRATION);
        }
        else {
            Player.Instance.StatusEffectRemove(GameControlType.StatusEffect.DEHYDRATION);
        }
        
        UpdateView();
    }

    public void UpdateView() {
    }
    
    private void DeathByDehydration() {
        var title = "갈사했습니다.";
        var content = "목이 타들어갑니다. 점점 시야가 흐려집니다...";

        GameEventGameOver.OnBadEndingGameOver.Invoke(title, content);
    }
}