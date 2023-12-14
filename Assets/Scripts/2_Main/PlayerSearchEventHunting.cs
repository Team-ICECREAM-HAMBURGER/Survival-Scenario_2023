using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSearchEventHunting : MonoBehaviour, IPlayerSearchEvent {
    public float Weight { get; set; }

    private Dictionary<string, int> resultItems; 
        
    
    public PlayerSearchEventHunting(float weight) {
        this.Weight = weight;
        this.resultItems = new Dictionary<string, int>();
    }
    
    public void Event() {
        // Debug
        Debug.Log("HuntingEvent");
        
        PlayerSearchResultView.Instance.Hunting((Hunting()) ? this.resultItems : null);
    }

    private bool Hunting() {
        this.resultItems.Clear();
        
        if (Player.Instance.Inventory[itemType.HUNTING_TOOL].Count >= 1) {
            int count = 0;
            
            // Item Acquire
            count = Player.Instance.Inventory[itemType.RAW_MEAT].Count;
            this.resultItems.Add(
                Player.Instance.Inventory[itemType.RAW_MEAT].ItemName, 
                (Player.Instance.Inventory[itemType.RAW_MEAT].ItemAcquire() - count));
            
            // Item Use
            count = Player.Instance.Inventory[itemType.HUNTING_TOOL].Count;
            this.resultItems.Add(
                Player.Instance.Inventory[itemType.HUNTING_TOOL].ItemName, 
                (Player.Instance.Inventory[itemType.HUNTING_TOOL].ItemUse() - count));
            
            return true;
        }
        else {
            return false;
        }
    }
}