using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
   
        PlayerSearchResultView.OnSearchResultUIFarming(Farming());
    }

    private string Farming() {
        string acquiredItems = "";
        
        for (int i = 0; i < Random.Range(2, 4); i++) {
            float randomPivot = Random.Range(0, 100);
            float weight = 0;
            
            foreach (var variable in 
                     Player.Instance.Inventory.Where(variable => 
                         variable.Value.IsAcquirable && variable.Value.EventType == eventType.FARMING)) {
                if (weight + variable.Value.Weight >= randomPivot) {
                    // IItem GET!
                    acquiredItems += variable.Value.ItemAcquire();   // return string "- 나무 +3 \n"
                    
                    break;
                }
                
                weight += variable.Value.Weight;
            }
        }

        return acquiredItems;
    }
}