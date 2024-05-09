using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusBodyHeat : MonoBehaviour, IPlayerStatus {
    public float LimitValue { get; } = 20f;
    public float CurrentValue { get; set; }
    public string Name { get; } = "체온";
    public GameControlType.Status Type { get; } = GameControlType.Status.BODY_HEAT;
    
    
    public void Invoke() {
        this.CurrentValue = Player.Instance.Status[this.Type];
        
        if (this.CurrentValue <= 0) {
            DeathByHypothermia();
        }
        else if (this.CurrentValue <= this.LimitValue) {
            Player.Instance.StatusEffectAdd(GameControlType.StatusEffect.COLDNESS);
        }
        else {
            Player.Instance.StatusEffectRemove(GameControlType.StatusEffect.COLDNESS);
        }
        
        // UpdateView();
    }

    // public void UpdateView() {
    //     this.statusGauge.value = this.CurrentValue;
    // }

    private void DeathByHypothermia() {
        var title = "동사했습니다.";
        var content = "냉혹한 추위 속에서 잠이 몰려옵니다...";
    }
}