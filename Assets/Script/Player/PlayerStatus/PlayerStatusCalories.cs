using UnityEngine;

public class PlayerStatusCalories : MonoBehaviour, IPlayerStatus {  // Presenter
    public float LimitValue { get; } = 15f;
    public float CurrentValue { get; private set; }
    
    public string Name { get; } = "칼로리";
    public GameControlType.Status Type { get; } = GameControlType.Status.CALORIES;
    

    public void Init() {
        this.CurrentValue = Player.Instance.Status[this.Type];
        PlayerInformation.OnStatusGaugeUpdate.Invoke(this.Type, this.CurrentValue);
    }

    public void StatusUpdate() {
        this.CurrentValue = Player.Instance.Status[this.Type];
        PlayerInformation.OnStatusGaugeUpdate.Invoke(this.Type, this.CurrentValue);
        
        if (this.CurrentValue <= 0) {   // Player Death
            GameEventGameOver.OnBadEnding.Invoke("아사했습니다.", "굶주림을 느낄 기력조차 남지 않았습니다.\n이제 남은 건 졸음 뿐입니다...");
        }
        else if (this.CurrentValue <= this.LimitValue) {    // Player Status Effect Active
            PlayerStatusEffectHunger.OnStatusEffectAdd.Invoke();
        }
        else if (Player.Instance.StatusEffect.ContainsKey(GameControlType.StatusEffect.COLDNESS)) {
            PlayerStatusEffectHunger.OnStatusEffectRemove.Invoke();
        }
    }
}