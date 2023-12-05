using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerSearchEventFarming : MonoBehaviour, IPlayerSearchEvent {
    public float Weight { get; set; }

    private Dictionary<string, int> acquiredItems = new Dictionary<string, int>();
    
    
    public PlayerSearchEventFarming(float weight) {
        this.Weight = weight;
    }
    
    public void Event() {
        // Debug
        Debug.Log("FarmingEvent");
        
        ItemRandomSelect();
   
        // Farming Result -> Text UI
        PlayerSearchResultView.Instance.Farming(this.acquiredItems);
    }

    private void ItemRandomSelect() {
        this.acquiredItems.Clear();
        
        for (int i = 0; i < Random.Range(2, 4); i++) {
            float randomPivot = Random.Range(0, 100);
            float weight = 0;
            
            foreach (var variable in Player.Instance.inventory) {
                if (variable.Value.IsAcquirable && variable.Value.EventType == eventType.FARMING) {
                    if (weight + variable.Value.Weight >= randomPivot) {
                        if (!this.acquiredItems.ContainsKey(variable.Value.ItemName)) {
                            int count = variable.Value.Count;
                            
                            variable.Value.ItemAcquire();
                            this.acquiredItems.Add(variable.Value.ItemName, (variable.Value.Count - count));
                        }
                        
                        break;
                    }
                    
                    weight += variable.Value.Weight;
                }
            }
        }
    }
}