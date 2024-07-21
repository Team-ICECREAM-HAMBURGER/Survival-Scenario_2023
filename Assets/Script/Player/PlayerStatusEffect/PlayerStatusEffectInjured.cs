using System.Text;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStatusEffectInjured : PlayerStatusEffect {   // Presenter
    private int limitTimeTerm;
    
    public override void Init() {
        this.Name = "부상";
        this.Term = 1;
        this.Type = GameControlType.StatusEffect.INJURED;
        
        this.limitTimeTerm = World.Instance.TimeTerm + this.Term;
        
        if (Player.Instance.StatusEffect.ContainsKey(this.Type)) {
            this.Term = Player.Instance.StatusEffect[this.Type];
            GameInformationMonitorPlayer.OnStatusEffectPanelUpdate.Invoke(this.Type, this.Name);
        }
    }

    public override void StatusEffectAdd() {
        var value = Random.Range(1, 5) * 500;
        
        if (this.Term < value) {
            this.Term = value;
        }
        else {
            this.Term += value;
        }
        
        this.limitTimeTerm = World.Instance.TimeTerm + this.Term;
        
        Player.Instance.StatusEffect.TryAdd(this.Type, this.Term);
        GameInformationMonitorPlayer.OnStatusEffectPanelUpdate.Invoke(this.Type, this.Name);
    }
    
    public override void StatusEffect() {
        if (this.limitTimeTerm <= World.Instance.TimeTerm) {    // TIME OUT
            PlayerStatusEffectManager.Instance.StatusEffectRemove(this.Type);
            return;
        }
        
        foreach (var VARIABLE in this.StatusReducePercents) {
            PlayerStatusManager.Instance.Statuses[VARIABLE.Key].StatusUpdate(-VARIABLE.Value);
        }
        
        GameInformationMonitorPlayer.OnStatusEffectPanelUpdate.Invoke(this.Type, this.Name);
    }
    
    public override void StatusEffectRemove() {
        Player.Instance.StatusEffect.Remove(this.Type);
        GameInformationMonitorPlayer.OnStatusEffectPanelUpdate.Invoke(this.Type, this.Name);
    }
}