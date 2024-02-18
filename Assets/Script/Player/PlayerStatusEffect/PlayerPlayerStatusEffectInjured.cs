using UnityEngine;

public class PlayerPlayerStatusEffectInjured : IPlayerStatusEffect {
    public string StatusEffectName { get; } = "부상";
    public GameTypeStatusEffect GameTypeStatusEffect { get; } = GameTypeStatusEffect.INJURED;
    public int DurationTerm { get; private set; }
    
    
    public void Event() {
        // GameInfoControl.OnTimeUpdateEvent += DurationTermUpdate;
        //
        // this.DurationTerm = Random.Range(3, 8) * 500;
        // Player.Instance.information.status[GameTypeStatus.STAMINA].StatusDecreaseMultiplier = 2f;
        //
        // Player.Instance.StatusEffectAdd(this.GameTypeStatusEffect);
        // GameInformation.OnPlayerStatusEffectIndicatorActiveEvent();
    }
    
    private void DurationTermUpdate(int value) {
        if (this.DurationTerm > 0) {
            this.DurationTerm -= value;
            
            return;
        }
        
        // Player.Instance.StatusEffectRemove(this.GameTypeStatusEffect);
        // GameInformation.OnPlayerStatusEffectIndicatorUpdateEvent();
    }
}