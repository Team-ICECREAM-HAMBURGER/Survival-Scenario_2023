public class PlayerStatusHydration : PlayerStatus { // Presenter
    public override void Init() {
        this.Name = "수분";
        this.Type = GameControlType.Status.HYDRATION;
        this.LimitValue = 30f;
        this.CurrentValue = Player.Instance.Status[this.Type];
        
        GameInformationMonitorPlayer.OnStatusGaugeUpdate.Invoke(this.Type, this.CurrentValue);
    }

    public override void StatusUpdate(float value) {
        base.StatusUpdate(value);
        
        if (this.CurrentValue <= 0) {   // Player Death
            PlayerStatusManager.Instance.PlayerDeath(GameControlType.PlayerDeath.DEATH_DEHYDRATION);
        } 
        else if (this.CurrentValue <= this.LimitValue) {    // Player Status Effect Active
            PlayerStatusManager.Instance.StatusEffectUpdate((GameControlType.StatusEffect.DEHYDRATION, GameControlType.StatusEffectUpdateType.EFFECT_ADD));
        }
        else if (Player.Instance.StatusEffect.ContainsKey(GameControlType.StatusEffect.DEHYDRATION)) {
            PlayerStatusManager.Instance.StatusEffectUpdate((GameControlType.StatusEffect.DEHYDRATION, GameControlType.StatusEffectUpdateType.EFFECT_REMOVE));
        }
    }
}