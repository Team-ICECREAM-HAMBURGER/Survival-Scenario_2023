using UnityEngine;

public class PlayerStatusEffectColdness : PlayerStatusEffect {  // Presenter
    public override void Init() {
        this.Name = "저채온증";
        this.Term = 1;
        this.Type = GameControlType.StatusEffect.COLDNESS;
        
        base.Init();
    }
    
    public override void StatusEffectAdd() {
        Player.Instance.StatusEffect.TryAdd(this.Type, this.Term);
        GameInformationMonitorPlayer.OnStatusEffectPanelUpdate.Invoke(this.Type, this.Name);
    }
    
    public override void StatusEffect(int value) {
        foreach (var VARIABLE in this.StatusReducePercents) {
            PlayerStatusManager.Instance.Status[VARIABLE.Key].StatusUpdate(-VARIABLE.Value);
        }
    }
    
    public override void StatusEffectRemove() {
        Player.Instance.StatusEffect.Remove(this.Type);
        GameInformationMonitorPlayer.OnStatusEffectPanelUpdate.Invoke(this.Type, this.Name);
    }
}