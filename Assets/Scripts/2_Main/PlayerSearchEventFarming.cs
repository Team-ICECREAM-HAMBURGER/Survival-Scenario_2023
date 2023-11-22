using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerSearchEventFarming : MonoBehaviour, IPlayerSearchEvent {
    public float Weight { get; set; }

    
    public PlayerSearchEventFarming(float weight) {
        this.Weight = weight;
    }
    
    public void Event() {
        // Debug
        Debug.Log("FarmingEvent");
        
        // Item Random select
        float randomPivot = Random.Range(0, 100);
        float weight = 0;

        foreach (var VARIABLE in Player.Instance.Inventory) {
            if (VARIABLE.Value.IsAcquirable) {
                if (VARIABLE.Value.Weight + weight >= randomPivot) {
                    VARIABLE.Value.ItemFarming();
                }
            }
        }
        
        // Player Status Update
        Player.Instance.StatusUpdate(20, 10, 10, 10);
    }
}