using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSearchEventHunting : MonoBehaviour, IPlayerSearchEvent {
    public float Weight { get; set; }
    
    
    public playerSearchEventHunting(float weight) {
        this.Weight = weight;
    }
    
    public void Event() {
        // Debug
        Debug.Log("HuntingEvent");
        
        // Weight Random Event
        
        // Player Status Update
        
    }
}
