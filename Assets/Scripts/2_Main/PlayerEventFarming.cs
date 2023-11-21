using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventFarming : MonoBehaviour, IPlayerEvent {
    public float Weight { get; set; }

    
    public PlayerEventFarming(float weight) {
        this.Weight = weight;
    }
    
    public void Event() {
        // Debug
        Debug.Log("FarmingEvent");
        
        // Item Random select
        
        
        
        // Item -> Inventory 
        
        
        
        
    }
}