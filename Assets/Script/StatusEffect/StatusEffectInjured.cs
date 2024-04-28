using UnityEngine;

public class StatusEffectInjured : StatusEffect {
    private float statusReduceMultiplier;
    
    
    public StatusEffectInjured() {
        this.name = "부상";
        this.type = GameControlType.StatusEffect.DURATION;
        this.term = Random.Range(1, 5) * 500;
    }

    public void Effect() {
        this.statusReduceMultiplier = 2f;
        
        GameInformation.OnPlayerGameDataSave();
        GameInformation.OnWorldGameDataSave();

        Player.Instance.StatusEffectUpdate(this);
    }

    private void Invoke(int value) {
        
    }
}