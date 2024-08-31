using UnityEngine;
using UnityEngine.Events;

public class PlayerStatusEffectHunger : PlayerStatusEffect {
    public override void Init() {
        this.Name = "기아";
        this.Term = 1;
        // this.PanelText;
        this.Type = GameControlType.StatusEffect.COLDNESS;
        // this.StatusReducePercents
        
        GameInformationMonitorPlayer.OnStatusEffectPanelUpdate.Invoke(this.Type, this.Name);
    }
    
    public override void StatusEffectAdd() {
        Player.Instance.StatusEffect.TryAdd(this.Type, this.Term);
        GameInformationMonitorPlayer.OnStatusEffectPanelUpdate.Invoke(this.Type, this.Name);
    }
    
    public override void StatusEffect() {
        foreach (var VARIABLE in this.StatusReducePercents) {
            PlayerStatusManager.Instance.Status[VARIABLE.Key].StatusUpdate(-VARIABLE.Value);
        }
    }
    
    public override void StatusEffectRemove() {
        Player.Instance.StatusEffect.Remove(this.Type);
        GameInformationMonitorPlayer.OnStatusEffectPanelUpdate.Invoke(this.Type, this.Name);
    }
}