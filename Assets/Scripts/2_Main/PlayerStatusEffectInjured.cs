using UnityEngine;

public class PlayerStatusEffectInjured : IPlayerStatusEffect {
    public int DurationTerm { get; set; }
    
    public string StatusEffectName { get; } = "부상";
    public statusEffectType StatusEffectType { get; } = statusEffectType.INJURED;

    
    public void Event() {
        this.DurationTerm = Random.Range(3, 8) * 500;

        if (!Player.Instance.CurrentStatusEffect.TryAdd(this.StatusEffectType, this.DurationTerm)) {
            Player.Instance.CurrentStatusEffect[this.StatusEffectType] = this.DurationTerm;
        }
        else {
            GameInfo.OnTimeUpdateEvent += DurationTermUpdate;
            Player.Instance.StatusReduceMultiplier = 2f;
        }
        
        GameInfoView.OnStatusEffectUIUpdateEvent($"{this.StatusEffectName} ({this.DurationTerm}텀)");
    }
    
    private void DurationTermUpdate(int value) {
        this.DurationTerm -= value;
        GameInfoView.OnStatusEffectUIUpdateEvent($"{this.StatusEffectName} ({this.DurationTerm}텀)");
    }
}