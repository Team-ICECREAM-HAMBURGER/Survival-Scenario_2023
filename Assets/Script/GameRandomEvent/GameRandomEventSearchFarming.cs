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
    private Dictionary<GameTypeItem, int> itemDic;
    
    
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
        this.itemList = ItemSpawnManager.OnMaterialItemGet();
        this.itemDic.Clear();

        foreach (var type in this.itemList.Select(VARIABLE => VARIABLE.ItemType).Where(type => !itemDic.TryAdd(type, 1))) {
            itemDic[type] += 1;
        }
        
        Player.Instance.InventoryUpdate(this.itemDic);
        
        // TODO: Result Text
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

        PlayerBehaviourSearch.OnSearchEventUpdateView(this.title, this.content.ToString());
    }
}