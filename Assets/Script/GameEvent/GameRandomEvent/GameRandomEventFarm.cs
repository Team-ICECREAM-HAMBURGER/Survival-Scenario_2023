using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameRandomEventFarm : MonoBehaviour, IGameRandomEvent { // Presenter
    [field: SerializeField] public float Percent { get; set; }
    private Dictionary<IItem, int> getItems;
    
    
    public void Event() {
        // Debug
        Debug.Log("FarmEvent");

        // Items Random Get
        this.getItems = GameEventManager.Instance.RandomItemWeightSelect(Random.Range(1, 3), ItemManager.Instance.FarmItems);
        
        // Player Inventory Update
        foreach (var VARIABLE in this.getItems) {
            ItemManager.Instance.FarmItems[VARIABLE.Key.ItemType].ItemAdd(VARIABLE.Value);
        }
    }
    
    public (string, string) EventResult() {
        var title = String.Empty;
        var content = new StringBuilder();
        
        title = "탐색 결과";
        content.Clear();
        
        content.Append("- 결과\n");
        content.Append("주변을 탐색하여 쓸만한 것들을 찾았다.\n");
        
        content.Append("\n");
        
        content.Append("- 획득한 아이템\n");
        
        foreach (var VARIABLE in this.getItems) {
            content.Append(VARIABLE.Key.Name);
            content.Append(" ");
            content.Append(VARIABLE.Value);
            content.Append("개\n");
        }

        return (title, content.ToString());
    }
}