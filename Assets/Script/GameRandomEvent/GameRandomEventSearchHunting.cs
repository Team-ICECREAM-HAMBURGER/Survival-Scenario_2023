using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameRandomEventSearchHunting : MonoBehaviour, IGameRandomEvent {   // Presenter
    public float Weight { get; private set; }

    [SerializeField] private string RequireItem;
    [SerializeField] private int RequireItemAmount;
    
    private string title;
    private StringBuilder content;
    private Dictionary<string, int> acquiredItems;
    private Dictionary<string, int> usedItems;
    private bool isHuntingSuccess;
    
    
    private void Init() {
        this.Weight = 95f;
        this.acquiredItems = new();
        this.usedItems = new();
        this.content = new();
    }

    private void Awake() {
        Init();
    }
    
    public void Event() {
        Debug.Log("HuntingEvent");
        
        this.isHuntingSuccess = false;
        Player.Instance.InventoryUpdate("사냥 도구", 1);
        
        if (Player.Instance.InventoryCheck(this.RequireItem)) {
            var items = ItemManager.Instance.HuntingSpawnItemsGet();
            
            this.acquiredItems.Clear();
            this.usedItems.Clear();
            this.isHuntingSuccess = true;
            
            Player.Instance.InventoryUpdate(this.RequireItem, -this.RequireItemAmount);

            if (!this.usedItems.TryAdd(this.RequireItem, this.RequireItemAmount)) {
                this.usedItems[this.RequireItem] += this.RequireItemAmount;
            }
            
            foreach (var VARIABLE in items.Where(
                         VARIABLE => !this.acquiredItems.TryAdd(VARIABLE.ItemName, 1))) {
                this.acquiredItems[VARIABLE.ItemName] += 1;
            }
            
            Player.Instance.InventoryUpdate(this.acquiredItems);
        }
        
        EventResult();
    }

    public void EventResult() {
        this.title = "탐색 결과";
        this.content.Clear();

        if (this.isHuntingSuccess) {
            this.content.Append("- 결과\n");
            this.content.Append("끈질긴 추격전 끝에 사냥에 성공했다.\n");
            
            this.content.Append("\n");
            
            this.content.Append("- 스테이터스 잔여량\n");
            this.content.Append($"체력: %\n");
            this.content.Append($"체온: %\n");
            this.content.Append($"수분: %\n");
            this.content.Append($"열량: %\n");
            
            this.content.Append("\n");

            this.content.Append("- 획득한 아이템\n");
            
            foreach (var VARIABLE in this.acquiredItems) {
                this.content.Append($"{VARIABLE.Key}: {VARIABLE.Value}\n");
            }
            
            this.content.Append("\n");
            
            this.content.Append("- 소모된 아이템\n");
            
            foreach (var VARIABLE in this.usedItems) {
                this.content.Append($"{VARIABLE.Key}: {VARIABLE.Value}\n");
            }
        }
        else {
           this.content.Append("- 결과\n");
           this.content.Append("사냥감을 잡을 마땅한 도구가 없어 놓치고 말았다.\n");
           this.content.Append("도구 제작은 '인벤토리' 메뉴에서 할 수 있다.\n");
           this.content.Append("우선 제작에 필요한 재료를 모아보자.\n");
        }
        
        PlayerBehaviourSearch.OnSearchEventUpdateView(this.title, this.content.ToString());
    }
}
