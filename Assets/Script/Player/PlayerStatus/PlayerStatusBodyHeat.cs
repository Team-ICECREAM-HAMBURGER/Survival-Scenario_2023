using UnityEngine;

public class PlayerStatusBodyHeat : MonoBehaviour, IPlayerStatus {
    public float LimitValue { get; } = 20f;
    public float CurrentValue { get; private set; }
    public string Name { get; } = "체온";
    public GameControlType.Status Type { get; } = GameControlType.Status.BODY_HEAT;
    

    public void Init() {
        this.CurrentValue = Player.Instance.Status[this.Type];
        PlayerInformationViewer.OnStatusGaugeUpdate.Invoke(this.Type, this.CurrentValue);
    }

    public void StatusUpdate() {
        this.CurrentValue = Player.Instance.Status[this.Type];
        PlayerInformationViewer.OnStatusGaugeUpdate.Invoke(this.Type, this.CurrentValue);
        
        if (this.CurrentValue <= 0) {   // Player Death
            GameEventGameOver.OnBadEnding.Invoke("동사했습니다.", "추위가 더위로 바뀌어갑니다.\n문득 몰려오는 아늑함에 눈꺼풀이 감깁니다...");
        }
        else if (this.CurrentValue <= this.LimitValue) {    // Player Status Effect Active
            PlayerStatusEffectColdness.OnStatusEffectAdd.Invoke();
        }
        else if (Player.Instance.StatusEffect.ContainsKey(GameControlType.StatusEffect.COLDNESS)) {
            PlayerStatusEffectColdness.OnStatusEffectRemove.Invoke();
        }
    }
}