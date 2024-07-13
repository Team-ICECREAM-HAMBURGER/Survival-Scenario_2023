public class PlayerStatusHydration : PlayerStatus { // Presenter
    public override void Init() {
        this.Name = "수분";
        this.Type = GameControlType.Status.HYDRATION;
        this.LimitValue = 30f;
        this.CurrentValue = Player.Instance.Status[this.Type];
        
        PlayerInformation.OnStatusGaugeUpdate.Invoke(this.Type, this.CurrentValue);
    }

    public override void StatusUpdate(float value) {
        this.CurrentValue += value;
        Player.Instance.Status[this.Type] = this.CurrentValue;
        
        PlayerInformation.OnStatusGaugeUpdate.Invoke(this.Type, this.CurrentValue);

        if (this.CurrentValue <= 0) {   // Player Death
            GameEventGameOver.OnBadEnding.Invoke("갈사했습니다.", "목이 타들어갑니다.\n한계를 느낄 무렵 시야가 흐려지기 시작합니다...");
        } 
        else if (this.CurrentValue <= this.LimitValue) {    // Player Status Effect Active
            PlayerStatusEffectManager.Instance.StatusEffectAdd(GameControlType.StatusEffect.DEHYDRATION);
        }
        else if (Player.Instance.StatusEffect.ContainsKey(GameControlType.StatusEffect.DEHYDRATION)) {
            PlayerStatusEffectManager.Instance.StatusEffectRemove(GameControlType.StatusEffect.DEHYDRATION);
        }
    }
}