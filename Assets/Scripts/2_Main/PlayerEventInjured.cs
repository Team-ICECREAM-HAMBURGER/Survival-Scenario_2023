using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventInjured : MonoBehaviour, IPlayerEvent {
    public float Weight { get; set; }

    
    public PlayerEventInjured(float weight) {
        this.Weight = weight;
    }
    
    public void Event() {
        Debug.Log("InjuredEvent");
    }
}