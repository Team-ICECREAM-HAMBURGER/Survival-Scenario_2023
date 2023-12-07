using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSearchEventInjured : MonoBehaviour, IPlayerSearchEvent {
    public float Weight { get; set; }

    
    public PlayerSearchEventInjured(float weight) {
        this.Weight = weight;
    }

    public void Event() {
        // Debug
        Debug.Log("InjuredEvent");
        
        // Event
        PlayerSearchResultView.Instance.Injured(Injured());
    }

    private int Injured() {
        Player.Instance.StatusEffect.TryAdd(statusEffectType.INJURED, new PlayerStatusEffectInjured());
        
        int duration = Player.Instance.StatusEffect[statusEffectType.INJURED].Duration;
        
        if (duration <= 0) {
            Player.Instance.StatusEffect.Remove(statusEffectType.INJURED);
        }
        
        Player.Instance.StatusEffect[statusEffectType.INJURED].StatusEffect();

        return duration;
    }
}