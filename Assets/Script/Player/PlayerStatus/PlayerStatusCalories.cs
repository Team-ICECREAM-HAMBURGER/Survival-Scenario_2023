public class PlayerStatusCalories : PlayerStatus {  // Presenter
    public override void Init() {
        this.Name = "칼로리";
        this.Type = GameControlType.Status.CALORIES;
        this.LimitValue = 15f;
        this.CurrentValue = Player.Instance.Status[this.Type];

        GameInformationMonitorPlayer.OnStatusGaugeUpdate.Invoke(this.Type, this.CurrentValue);
    }

    public override void StatusUpdate(float value) {
        this.CurrentValue += value;
        Player.Instance.Status[this.Type] = this.CurrentValue;
        
        GameInformationMonitorPlayer.OnStatusGaugeUpdate.Invoke(this.Type, this.CurrentValue);
        
        if (this.CurrentValue <= 0) {   // Player Death
            GameEventGameOver.OnBadEnding.Invoke("아사했습니다.", "굶주림을 느낄 기력조차 남지 않았습니다.\n이제 남은 건 졸음 뿐입니다...");
        }
        else if (this.CurrentValue <= this.LimitValue) {
            PlayerStatusEffectManager.Instance.StatusEffectAdd(GameControlType.StatusEffect.HUNGER);
        }
        else if (Player.Instance.StatusEffect.ContainsKey(GameControlType.StatusEffect.HUNGER)) {
            PlayerStatusEffectManager.Instance.StatusEffectRemove(GameControlType.StatusEffect.HUNGER);
        }
    }
}