using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class playerSearchEventFarming : MonoBehaviour, IPlayerSearchEvent {
    public float Weight { get; set; }

    
    public playerSearchEventFarming(float weight) {
        this.Weight = weight;
    }
    
    public void Event() {
        // Debug
        Debug.Log("FarmingEvent");
        
        // Item Random select
        float randomPivot = Random.Range(0, 100);
        float weight = 0; 

        // Debug
        Debug.Log("random pivot : " + randomPivot);
        
        foreach (var variable in player.instance.inventory) {
            if (variable.Value.IsAcquirable) {
                if (variable.Value.Weight + weight >= randomPivot) {
                    variable.Value.ItemFarming();

                    // Debug
                    Debug.Log("item type: " + variable.Key);
                    Debug.Log("item weight: " + variable.Value.Weight);
                    Debug.Log("item get: " + variable.Value.Count);
                }
                
                weight += variable.Value.Weight;
            }
        }
        
        // Player Status Update
        player.instance.StatusUpdate(20, 10, 10, 10);
    }
}