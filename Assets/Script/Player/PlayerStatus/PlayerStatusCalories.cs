public class PlayerStatusCalories : PlayerStatus {  // Presenter
    public override void Init() {
        this.Name = "칼로리";
        this.Type = GameControlType.Status.CALORIES;
        this.LimitValue = 15f;
        this.CurrentValue = Player.Instance.Status[this.Type];

        base.Init();
    }

    public override void StatusUpdate(float value) {
        base.StatusUpdate(value);
        
        if (this.CurrentValue <= 0) {   // Player Death
            PlayerStatusManager.Instance.PlayerDeath(GameControlType.PlayerDeath.DEATH_HUNGER);
        }
        else if (this.CurrentValue <= this.LimitValue) {
            PlayerStatusManager.Instance.StatusEffectUpdate((GameControlType.StatusEffect.HUNGER, GameControlType.StatusEffectUpdateType.EFFECT_ADD));
        }
        else if (Player.Instance.StatusEffect.ContainsKey(GameControlType.StatusEffect.HUNGER)) {
            PlayerStatusManager.Instance.StatusEffectUpdate((GameControlType.StatusEffect.HUNGER, GameControlType.StatusEffectUpdateType.EFFECT_REMOVE));
        }
    }
}