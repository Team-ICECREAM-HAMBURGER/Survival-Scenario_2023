public class PlayerStatusStamina : PlayerStatus {   // Presenter
    public override void Init() {
        this.Name = "체력";
        this.Type = GameControlType.Status.STAMINA;
        this.LimitValue = 30f;
        this.CurrentValue = Player.Instance.Status[this.Type];
        
        PlayerInformation.OnStatusGaugeUpdate.Invoke(this.Type, this.CurrentValue);
    }

    public override void StatusUpdate(float value) {
        this.CurrentValue += value;
        Player.Instance.Status[this.Type] = this.CurrentValue;
        
        PlayerInformation.OnStatusGaugeUpdate.Invoke(this.Type, this.CurrentValue);
        
        if (this.CurrentValue <= this.LimitValue) {
            PlayerStatusEffectManager.Instance.StatusEffectAdd(GameControlType.StatusEffect.EXHAUSTION);
        }
        else if (Player.Instance.StatusEffect.ContainsKey(GameControlType.StatusEffect.EXHAUSTION)) {
            PlayerStatusEffectManager.Instance.StatusEffectRemove(GameControlType.StatusEffect.EXHAUSTION);
        }
    }
}