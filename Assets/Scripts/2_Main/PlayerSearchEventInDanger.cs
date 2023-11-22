using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSearchEventInDanger : MonoBehaviour, IPlayerSearchEvent {
    public float Weight { get; set; }

    
    public PlayerSearchEventInDanger(float weight) {
        this.Weight = weight;
    }
    
    public void Event() {
        Debug.Log("InDangerEvent");
    }
}