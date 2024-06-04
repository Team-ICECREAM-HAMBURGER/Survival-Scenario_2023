using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class GameRandomEventHunting : MonoBehaviour, IGameRandomEvent {   // Presenter
    [field: SerializeField] public float Percent { get; set; }

    // TODO: 사냥 가능 조건 부분 수정 필요
    private string spendItem;
    private int spendItemAmount;
    
    private Dictionary<string, int> acquiredItems;
    private Dictionary<string, int> spentItems;
    private bool isHuntingSuccess;
    
    
    private void Init() {
        this.acquiredItems = new();
        this.spentItems = new();
    }

    private void Awake() {
        Init();
    }
    
    public void Event() {
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
    }

    public (string, string) EventResult() {
        var title = String.Empty;
        var content = new StringBuilder();
        
        title = "탐색 결과";
        content.Clear();

        if (this.isHuntingSuccess) {
            content.Append("- 결과\n");
            content.Append("끈질긴 추격전 끝에 사냥에 성공했다.\n");
            
            content.Append("\n");

            content.Append("- 획득한 아이템\n");
            
            foreach (var VARIABLE in this.acquiredItems) {
                content.Append($"{VARIABLE.Key}: {VARIABLE.Value}\n");
            }
            
            content.Append("\n");
            
            content.Append("- 소모된 아이템\n");
            
            foreach (var VARIABLE in this.spentItems) {
                content.Append($"{VARIABLE.Key}: {VARIABLE.Value}\n");
            }
        }
        else {
           content.Append("- 결과\n");
           content.Append("사냥감을 잡을 마땅한 도구가 없어 놓치고 말았다.\n");
           content.Append("도구 제작은 '인벤토리' 메뉴에서 할 수 있다.\n");
           content.Append("우선 제작에 필요한 재료를 모아보자.\n");
        }

        return (title, content.ToString());
    }
}
