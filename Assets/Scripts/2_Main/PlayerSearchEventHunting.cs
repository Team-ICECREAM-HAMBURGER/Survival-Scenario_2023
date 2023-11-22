using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSearchEventHunting : MonoBehaviour, IPlayerSearchEvent {
    public float Weight { get; set; }
    
    
    public PlayerSearchEventHunting(float weight) {
        this.Weight = weight;
    }
    
    public void Event() {
        // Debug
        Debug.Log("HuntingEvent");
        
        // Weight Random Event
        
        // Player Status Update
        
    }
}
