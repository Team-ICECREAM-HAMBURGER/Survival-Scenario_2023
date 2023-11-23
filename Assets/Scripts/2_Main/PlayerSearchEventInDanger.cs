using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSearchEventInDanger : MonoBehaviour, IPlayerSearchEvent {
    public float Weight { get; set; }

    
    public playerSearchEventInDanger(float weight) {
        this.Weight = weight;
    }
    
    public void Event() {
        Debug.Log("InDangerEvent");
    }
}