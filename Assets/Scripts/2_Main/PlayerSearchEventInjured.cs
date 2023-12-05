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
        Injured();
        
        // UI Update
        PlayerSearchResultView.Instance.Injured();
    }

    private void Injured() {
        if (!Player.Instance.StatusEffect.ContainsKey(statusEffectType.INJURED)) {
            Player.Instance.StatusEffect.Add(statusEffectType.INJURED, new PlayerStatusEffectInjured());
        }
        else {
            Player.Instance.StatusEffect[statusEffectType.INJURED].StatusEffect();
        }
    }
}