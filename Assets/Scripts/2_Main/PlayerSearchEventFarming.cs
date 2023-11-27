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
        for (int i = 0; i < Random.Range(2, 4); i++) {
            float randomPivot = Random.Range(0, 100);
            float weight = 0;
            
            // Debug
            Debug.Log("random pivot : " + randomPivot + 
                      " weight : " + weight);
            
            foreach (var variable in player.instance.inventory) {
                if (variable.Value.IsAcquirable && variable.Value.EventType == eventType.FARMING) {
                    if (weight + variable.Value.Weight >= randomPivot) {
                        variable.Value.ItemAcquire();

                        // Debug
                        Debug.Log("----------//RESULT//----------");
                        Debug.Log("item type: " + variable.Key + 
                                  " item weight: " + variable.Value.Weight + 
                                  " item count: " + variable.Value.Count);
                        Debug.Log("----------//--!!--//----------");
                        break;
                    }
                    
                    // Debug
                    Debug.Log("item type: " + variable.Key + 
                              " item weight: " + variable.Value.Weight + 
                              " item count: " + variable.Value.Count);
                    
                    // TODO: Farming Result -> Text UI
                    weight += variable.Value.Weight;
                }
            }
        }
        
        // Player Status Update
        player.instance.StatusUpdate(20, 10, 10, 10);
    }
}