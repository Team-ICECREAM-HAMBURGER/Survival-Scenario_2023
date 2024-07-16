public class PlayerStatusEffectDehydration : PlayerStatusEffect {
    public override void Init() {
        this.Name = "탈수";
        this.Term = 1;
        // this.PanelText;
        this.Type = GameControlType.StatusEffect.DEHYDRATION;
        // this.StatusReducePercents;
        
        PlayerInformation.OnStatusEffectPanelUpdate.Invoke(this.Type, this.Name);
    }

    public override void StatusEffectAdd() {
        Player.Instance.StatusEffect.TryAdd(this.Type, this.Term);
        PlayerInformation.OnStatusEffectPanelUpdate.Invoke(this.Type, this.Name);
    }

    public override void StatusEffect() {
        foreach (var VARIABLE in this.StatusReducePercents) {
            PlayerStatusManager.Instance.Statuses[VARIABLE.Key].StatusUpdate(-VARIABLE.Value);
        }
    }
    
    public override void StatusEffectRemove() {
        Player.Instance.StatusEffect.Remove(this.Type);
        PlayerInformation.OnStatusEffectPanelUpdate.Invoke(this.Type, this.Name);
    }
}