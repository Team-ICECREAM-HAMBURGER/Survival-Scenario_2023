public class PlayerStatusBodyHeat : PlayerStatus {  // Presenter
    public override void Init() {
        this.Name = "체온";
        this.Type = GameControlType.Status.BODY_HEAT;
        this.LimitValue = 20f;
        this.CurrentValue = Player.Instance.Status[this.Type];
        
        base.Init();
    }

    public override void StatusUpdate(float value) {
        base.StatusUpdate(value);
        
        if (this.CurrentValue <= 0) {   // Player Death
            PlayerStatusManager.Instance.PlayerDeath(GameControlType.PlayerDeath.DEATH_COLDNESS);
        }
        else if (this.CurrentValue <= this.LimitValue) {
            PlayerStatusManager.Instance.StatusEffectUpdate((GameControlType.StatusEffect.COLDNESS, GameControlType.StatusEffectUpdateType.EFFECT_ADD));
        } 
        else if (Player.Instance.StatusEffect.ContainsKey(GameControlType.StatusEffect.COLDNESS)) { 
            PlayerStatusManager.Instance.StatusEffectUpdate((GameControlType.StatusEffect.COLDNESS, GameControlType.StatusEffectUpdateType.EFFECT_REMOVE));
        }
    }
}