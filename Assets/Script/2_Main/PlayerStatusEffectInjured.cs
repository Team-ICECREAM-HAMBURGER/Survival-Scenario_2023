using UnityEngine;

[System.Serializable]
public class PlayerStatusEffectInjured : IPlayerStatusEffect {
    public string StatusEffectName { get; } = "부상";
    public StatusEffectType StatusEffectType { get; } = StatusEffectType.INJURED;

    public int DurationTerm { get; private set; }
    
    
    public void Event() {
        GameInfoControl.OnTimeUpdateEvent += DurationTermUpdate;

        this.DurationTerm = Random.Range(3, 8) * 500;
        Player.Instance.StatusReduceMultiplier = 2f;
        //Player.Instance.StatusEffectAdd();
        PlayerInfoView.OnPlayerStatusEffectIndicatorOnEvent();
    }
    
    private void DurationTermUpdate(int value) {
        if (this.DurationTerm > 0) {
            this.DurationTerm -= value;
            
            return;
        }
        
        //Player.Instance.StatusEffectRemove();
        PlayerInfoView.OnPlayerStatusEffectIndicatorUpdateEvent();
    }
}