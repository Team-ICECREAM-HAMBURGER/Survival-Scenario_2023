using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSearchEventInjured : MonoBehaviour, IPlayerSearchEvent {
    public float Weight { get; set; }

    
    public playerSearchEventInjured(float weight) {
        this.Weight = weight;
    }
    
    public void Event() {
        Debug.Log("InjuredEvent");
    }
}