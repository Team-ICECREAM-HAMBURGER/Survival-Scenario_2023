using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameRandomEventFarming : MonoBehaviour, IGameRandomEvent { // Presenter
    [field: SerializeField] public float Weight { get; set; }
    private Dictionary<string, int> getItems;
    
    
    public void Event() {
        // Debug
        Debug.Log("FarmingEvent");

        this.getItems = ItemManager.Instance.RandomItemGet(Random.Range(1, 3));
        Player.Instance.InventoryUpdate(this.getItems);
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
            content.Append(VARIABLE.Key);
            content.Append(" ");
            content.Append(VARIABLE.Value);
            content.Append("개\n");
        }

        return (title, content.ToString());
    }
}