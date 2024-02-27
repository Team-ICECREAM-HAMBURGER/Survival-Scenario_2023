using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameRandomEventSearchFarming : MonoBehaviour, IGameRandomEvent { // Presenter
    public float Weight { get; private set; }
    
    private string title;
    private StringBuilder content;
    private List<IItem> itemList;
    private Dictionary<string, int> itemDic;
    
    
    private void Init() {
        this.Weight = 90f;
        this.itemList = new();
        this.itemDic = new();
        this.content = new();
    }

    private void Awake() {
        Init();
    }
    
    public void Event() {
        // Debug
        Debug.Log("FarmingEvent");
        
        // Item Random Get Event
        this.itemList = ItemManager.OnMaterialItemGet();
        this.itemDic.Clear();

        foreach (var VARIABLE in this.itemList) {
            var key = VARIABLE.ItemName;
            
            if (!this.itemDic.TryAdd(key, 1)) {
                this.itemDic[key] += 1;
            }
        }
        
        Player.Instance.InventoryUpdate(this.itemDic);
        
        // UI Update
        EventResult();
    }

    public void EventResult() {
        this.title = "탐색 결과";

        this.content.Clear();
        
        this.content.Append("- 결과\n");
        this.content.Append("주변을 탐색하여 쓸만한 것들을 찾았다.\n");

        this.content.Append("\n");
        
        this.content.Append("- 스테이터스 잔여량\n");
        this.content.Append($"체력: %\n");
        this.content.Append($"체온: %\n");
        this.content.Append($"수분: %\n");
        this.content.Append($"열량: %\n");
        
        this.content.Append("\n");
        
        this.content.Append("- 획득한 아이템\n");

        foreach (var VARIABLE in this.itemDic) {
            this.content.Append($"{VARIABLE.Key}: {VARIABLE.Value}\n");
        }
        
        PlayerBehaviourSearch.OnSearchEventUpdateView(this.title, this.content.ToString());
    }
}