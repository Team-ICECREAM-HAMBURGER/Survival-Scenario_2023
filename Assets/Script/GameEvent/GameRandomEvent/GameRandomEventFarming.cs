using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameRandomEventFarming : MonoBehaviour, IGameRandomEvent { // Presenter
    [field: SerializeField] public float Weight { get; set; }
    
    private string title;
    private StringBuilder content;
    private Dictionary<string, int> acquiredItems;
    
    
    private void Init() {
        this.acquiredItems = new();
        this.title = String.Empty;
        this.content = new();
    }

    private void Awake() {
        Init();
    }
    
    public (string, string) Event() {
        // Debug
        Debug.Log("FarmingEvent");
        
        // Item Random Get Event
        this.acquiredItems.Clear();

        for (var i = 0; i < Random.Range(1, 5); i++) {
            var pivot = Random.Range(0, 1f);
            var randomWeightSum = 0f;

            foreach (var VARIABLE in ItemManager.Instance.FarmingItems) {
                randomWeightSum += VARIABLE.randomWeight;

                if (randomWeightSum >= pivot) {
                    // TODO: 획득 개수 무작위 함수 적용
                    if (!this.acquiredItems.TryAdd(VARIABLE.ItemName, 1)) {
                        this.acquiredItems[VARIABLE.ItemName] += 1;
                    }
                    
                    break;
                }
            }
        }
        
        Player.Instance.InventoryUpdate(this.acquiredItems);
        
        // UI Update
        EventResult();

        return (this.title, this.content.ToString());
    }

    public void EventResult() {
        this.title = "탐색 결과";
        this.content.Clear();
        
        this.content.Append("- 결과\n");
        this.content.Append("주변을 탐색하여 쓸만한 것들을 찾았다.\n");
        
        this.content.Append("\n");
        
        this.content.Append("- 획득한 아이템\n");

        foreach (var VARIABLE in this.acquiredItems) {
            this.content.Append($"{VARIABLE.Key}: {VARIABLE.Value}\n");
        }
    }
}