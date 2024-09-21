public class PlayerStatusStamina : PlayerStatus {   // Presenter
    public override void Init() {
        this.Name = "체력";
        this.Type = GameControlType.Status.STAMINA;
        this.LimitValue = 30f;
        this.CurrentValue = Player.Instance.Status[this.Type];
        
        base.Init();
    }

    public override void StatusUpdate(float value) {
        base.StatusUpdate(value);
        
        if (this.CurrentValue <= this.LimitValue) {
            PlayerStatusManager.Instance.StatusEffectUpdate((GameControlType.StatusEffect.EXHAUSTION, GameControlType.StatusEffectUpdateType.EFFECT_ADD));
        }
        else if (Player.Instance.StatusEffect.ContainsKey(GameControlType.StatusEffect.EXHAUSTION)) {
            PlayerStatusManager.Instance.StatusEffectUpdate((GameControlType.StatusEffect.EXHAUSTION, GameControlType.StatusEffectUpdateType.EFFECT_REMOVE));
        }
    }
}