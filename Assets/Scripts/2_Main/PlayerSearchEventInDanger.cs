using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSearchEventInDanger : MonoBehaviour, IPlayerSearchEvent {
    public float Weight { get; set; }

    
    public PlayerSearchEventInDanger(float weight) {
        this.Weight = weight;
    }
    
    public void Event() {
        // Debug
        Debug.Log("InDangerEvent");
        
        // Event
        //PlayerSearchResultView.Instance.InDanger(InDanger());
    }

    private int InDanger() {
        var itemHuntingTool = Player.Instance.Inventory[itemType.HUNTING_TOOL];
        
        //Player.Instance.CurrentStatusEffect.TryAdd(statusEffectType.EXHAUSTION, new PlayerStatusEffectInjured());
        
        if (itemHuntingTool.Count > 0) {
            itemHuntingTool.ItemUse();

            return 0;
        }

        //Player.Instance.CurrentStatusEffect.TryAdd(statusEffectType.INJURED, new PlayerStatusEffectInjured());
        int duration = Player.Instance.CurrentStatusEffect[statusEffectType.INJURED];
        
        return duration;
    }
}