public class PlayerStatusBodyHeat : PlayerStatus {  // Presenter
    public override void Init() {
        this.Name = "체온";
        this.Type = GameControlType.Status.BODY_HEAT;
        this.LimitValue = 20f;
        this.CurrentValue = Player.Instance.Status[this.Type];
        
        GameInformationMonitorPlayer.OnStatusGaugeUpdate.Invoke(this.Type, this.CurrentValue);
    }

    public override void StatusUpdate(float value) {
        base.StatusUpdate(value);
        
        if (this.CurrentValue <= 0) {   // Player Death
            GameEventGameOver.OnBadEnding.Invoke("동사했습니다.", "추위가 더위로 바뀌어갑니다.\n문득 몰려오는 아늑함에 눈꺼풀이 감깁니다...");
        }
        else if (this.CurrentValue <= this.LimitValue) {
            PlayerStatusEffectManager.Instance.StatusEffectAdd(GameControlType.StatusEffect.COLDNESS);
        } 
        else if (Player.Instance.StatusEffect.ContainsKey(GameControlType.StatusEffect.COLDNESS)) { 
            PlayerStatusEffectManager.Instance.StatusEffectRemove(GameControlType.StatusEffect.COLDNESS);
        }
    }
}