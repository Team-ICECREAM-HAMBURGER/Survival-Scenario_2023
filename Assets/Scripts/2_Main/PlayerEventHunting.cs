using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventHunting : MonoBehaviour, IPlayerEvent {
    public float Weight { get; set; }
    
    
    public PlayerEventHunting(float weight) {
        this.Weight = weight;
    }
    
    public void Event() {
        Debug.Log("HuntingEvent");
    }
}
