using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventInDanger : MonoBehaviour, IPlayerEvent {
    public float Weight { get; set; }

    
    public PlayerEventInDanger(float weight) {
        this.Weight = weight;
    }
    
    public void Event() {
        Debug.Log("InDangerEvent");
    }
}