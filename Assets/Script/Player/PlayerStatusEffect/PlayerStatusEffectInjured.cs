using UnityEngine;

public class PlayerStatusEffectInjured : PlayerStatusEffect {   // Presenter
    private int limitTimeTerm;
    
    public override void Init() {
        this.Name = "부상";
        this.Term = 0;
        this.Type = GameControlType.StatusEffect.INJURED;
        
        base.Init();
    }

    public override void StatusEffectAdd() {
        var value = Random.Range(1, 5) * 500;
        
        if (this.Term < value) {
            this.Term = value;
        }
        else {
            this.Term += value;
        }
        
        Player.Instance.StatusEffect.TryAdd(this.Type, this.Term);
        GameInformationMonitorPlayer.OnStatusEffectPanelUpdate.Invoke(this.Type, this.Name);
    }
    
    public override void StatusEffect(int value) {
        this.Term -= value;
        
        if (this.Term <= 0) {    // TIME OUT
            PlayerStatusEffectManager.Instance.StatusEffectRemove(this.Type);
            
            return;
        }
        
        foreach (var VARIABLE in this.StatusReducePercents) {
            PlayerStatusManager.Instance.Statuses[VARIABLE.Key].StatusUpdate(-VARIABLE.Value);
        }
        
        GameInformationMonitorPlayer.OnStatusEffectPanelUpdate.Invoke(this.Type, this.Name);
        Player.Instance.StatusEffect[this.Type] = this.Term;
    }
    
    public override void StatusEffectRemove() {
        Player.Instance.StatusEffect.Remove(this.Type);
        GameInformationMonitorPlayer.OnStatusEffectPanelUpdate.Invoke(this.Type, this.Name);
    }
}