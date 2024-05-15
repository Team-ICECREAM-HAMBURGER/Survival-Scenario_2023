using UnityEngine;

public class PlayerStatusHydration : MonoBehaviour, IPlayerStatus {
    public float LimitValue { get; } = 30f;
    public float CurrentValue { get; private set; }
    
    public string Name { get; } = "수분";
    public GameControlType.Status Type { get; } = GameControlType.Status.HYDRATION;
    
    
    public void Init() {
        this.CurrentValue = Player.Instance.Status[this.Type];
        PlayerInformationViewer.OnStatusGaugeUpdate.Invoke(this.Type, this.CurrentValue);
    }

    public void StatusUpdate() {
        this.CurrentValue = Player.Instance.Status[this.Type];
        PlayerInformationViewer.OnStatusGaugeUpdate.Invoke(this.Type, this.CurrentValue);

        if (this.CurrentValue <= 0) {   // Player Death
            GameEventGameOver.OnBadEnding.Invoke("갈사했습니다.", "목이 타들어갑니다.\n한계를 느낄 무렵 시야가 흐려지기 시작합니다...");
        } 
        else if (this.CurrentValue <= this.LimitValue) {    // Player Status Effect Active
            PlayerStatusEffectDehydration.OnStatusEffectAdd.Invoke();
        }
        else if (Player.Instance.StatusEffect.ContainsKey(GameControlType.StatusEffect.COLDNESS)) {
            PlayerStatusEffectDehydration.OnStatusEffectRemove.Invoke();
        }
    }
}