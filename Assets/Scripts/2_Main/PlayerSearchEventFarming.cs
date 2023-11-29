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
        for (int i = 0; i < Random.Range(2, 4); i++) {
            float randomPivot = Random.Range(0, 100);
            float weight = 0;
            
            Dictionary<Item, int> acquiredItems = new Dictionary<Item, int>();
            
            foreach (var variable in player.instance.inventory) {
                if (variable.Value.IsAcquirable && variable.Value.EventType == eventType.FARMING) {
                    if (weight + variable.Value.Weight >= randomPivot) {
                        int count = variable.Value.Count;
                        
                        variable.Value.ItemAcquire();
                        acquiredItems.Add(variable.Value, (variable.Value.Count - count));
                        break;
                    }
                    
                    // TODO: Farming Result -> Text UI
                    PlayerSearchResultView.Instance.Farming(acquiredItems);
                    
                    weight += variable.Value.Weight;
                }
            }
        }
        
        // Player Status Update
        player.instance.StatusUpdate(20, 10, 10, 10);
    }
}