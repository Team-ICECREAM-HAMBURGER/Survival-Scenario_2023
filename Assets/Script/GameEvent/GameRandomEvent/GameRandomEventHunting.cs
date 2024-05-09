using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class GameRandomEventHunting : MonoBehaviour, IGameRandomEvent {   // Presenter
    [field: SerializeField] public float Weight { get; set; }

    // TODO: 사냥 가능 조건 부분 수정 필요
    private string spendItem;
    private int spendItemAmount;
    
    private string title;
    private StringBuilder content;
    private Dictionary<string, int> acquiredItems;
    private Dictionary<string, int> spentItems;
    private bool isHuntingSuccess;
    
    
    private void Init() {
        //this.Weight = 0f;
        this.acquiredItems = new();
        this.spentItems = new();
        this.content = new();
    }

    private void Awake() {
        Init();
    }
    
    public (string, string) Event() {
        // Debug.Log("HuntingEvent");
        //
        // this.isHuntingSuccess = false;
        //
        // if (Player.Instance.InventoryCheck(this.spendItem)) {
        //     this.isHuntingSuccess = true;
        //     
        //     // Item Random Get Event
        //     this.acquiredItems.Clear();
        //
        //     for (var i = 0; i < Random.Range(1, 5); i++) {
        //         var pivot = Random.Range(0, 1f);
        //         var randomWeightSum = 0f;
        //
        //         foreach (var VARIABLE in ItemManager.Instance.HuntingItems) {
        //             randomWeightSum += VARIABLE.randomWeight;
        //
        //             if (randomWeightSum >= pivot) {
        //                 if (!this.acquiredItems.TryAdd(VARIABLE.ItemName, 1)) {
        //                     this.acquiredItems[VARIABLE.ItemName] += 1;
        //                 }
        //             
        //                 break;
        //             }
        //         }
        //     }
        //     
        //     Player.Instance.InventoryUpdate(this.acquiredItems);
        //     
        //     // Item Spend
        //     this.spentItems.Clear();
        //     
        //     if (!this.spentItems.TryAdd(this.spendItem, this.spendItemAmount)) {
        //         this.spentItems[this.spendItem] += this.spendItemAmount;
        //     }
        //     
        //     Player.Instance.InventoryUpdate(this.spendItem, -this.spendItemAmount);
        // }
        //
        // EventResult();
        //
        return (this.title, this.content.ToString());
    }

    public void EventResult() {
        this.title = "탐색 결과";
        this.content.Clear();

        if (this.isHuntingSuccess) {
            this.content.Append("- 결과\n");
            this.content.Append("끈질긴 추격전 끝에 사냥에 성공했다.\n");
            
            this.content.Append("\n");

            this.content.Append("- 획득한 아이템\n");
            
            foreach (var VARIABLE in this.acquiredItems) {
                this.content.Append($"{VARIABLE.Key}: {VARIABLE.Value}\n");
            }
            
            this.content.Append("\n");
            
            this.content.Append("- 소모된 아이템\n");
            
            foreach (var VARIABLE in this.spentItems) {
                this.content.Append($"{VARIABLE.Key}: {VARIABLE.Value}\n");
            }
        }
        else {
           this.content.Append("- 결과\n");
           this.content.Append("사냥감을 잡을 마땅한 도구가 없어 놓치고 말았다.\n");
           this.content.Append("도구 제작은 '인벤토리' 메뉴에서 할 수 있다.\n");
           this.content.Append("우선 제작에 필요한 재료를 모아보자.\n");
        }
    }
}
