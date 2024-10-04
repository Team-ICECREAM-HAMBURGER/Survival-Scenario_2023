using UnityEngine;
using UnityEngine.Events;

public class PlayerStatusEffectHunger : PlayerStatusEffect {
    public override void Init() {
        this.Name = "기아";
        this.Term = 1;
        this.Type = GameControlType.StatusEffect.COLDNESS;
        
        base.Init();
    }
    
    public override void StatusEffectAdd() {
        Player.Instance.StatusEffect.TryAdd(this.Type, this.Term);
        GameInformationMonitorManager.Instance.StatusEffectPanelUpdate(this.Type, this.Name);
    }
    
    public override void StatusEffect(int value) {
        foreach (var VARIABLE in this.StatusReducePercents) {
            PlayerStatusManager.Instance.Statuses[VARIABLE.Key].StatusUpdate(-VARIABLE.Value);
        }
    }
    
    public override void StatusEffectRemove() {
        Player.Instance.StatusEffect.Remove(this.Type);
        GameInformationMonitorManager.Instance.StatusEffectPanelUpdate(this.Type, this.Name);
    }
}