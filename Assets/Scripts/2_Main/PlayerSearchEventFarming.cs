using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerSearchEventFarming : MonoBehaviour, IPlayerSearchEvent {
    public float Weight { get; set; }

    private readonly StringBuilder resultText;
    
    
    public PlayerSearchEventFarming(float weight) {
        this.Weight = weight;
        this.resultText = new StringBuilder();
    }
    
    public void Event() {
        // Debug
        Debug.Log("FarmingEvent");
   
        PlayerSearchResultView.OnSearchResultUIFarming(Farming());
    }

    private string Farming() {
        this.resultText.Clear();
        
        for (int i = 0; i < Random.Range(2, 4); i++) {
            float randomPivot = Random.Range(0, 100);
            float weight = 0;
            
            foreach (var variable in Player.Instance.Inventory.Where(
                         variable => variable.Value.EventType == eventType.FARMING)) {
                if (weight + variable.Value.Weight >= randomPivot) {
                    // Item Get
                    var acquiredItemCount = variable.Value.ItemAcquire();
                    
                    // UI Text
                    this.resultText.Append("- ");
                    this.resultText.Append(variable.Value.ItemName);
                    this.resultText.Append(" ");
                    this.resultText.Append(acquiredItemCount.ToString("+#; -#; 0"));
                    this.resultText.Append("\n");
                    
                    break;
                }
                
                weight += variable.Value.Weight;
            }
        }

        return this.resultText.ToString();
    }
}