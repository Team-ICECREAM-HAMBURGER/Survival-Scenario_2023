using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class GameRandomEventHunt : GameRandomEvent {   // Presenter
    // TODO: 사냥 가능 조건 부분 수정 필요
    private string spendItem;
    private int spendItemAmount;
    
    private Dictionary<string, int> acquiredItems;
    private Dictionary<string, int> spentItems;
    private bool isHuntingSuccess;
    
    
    public override void Init() {
        this.Percent = 5;
        
        this.acquiredItems = new();
        this.spentItems = new();
    }
    
    public override void Event() {
        Debug.Log("HuntingEvent");
    }

    // public override (string, string) EventResult() {
    //     var title = String.Empty;
    //     var content = new StringBuilder();
    //     
    //     title = "탐색 결과";
    //     content.Clear();
    //
    //     if (this.isHuntingSuccess) {
    //         content.Append("- 결과\n");
    //         content.Append("끈질긴 추격전 끝에 사냥에 성공했다.\n");
    //         
    //         content.Append("\n");
    //
    //         content.Append("- 획득한 아이템\n");
    //         
    //         foreach (var VARIABLE in this.acquiredItems) {
    //             content.Append($"{VARIABLE.Key}: {VARIABLE.Value}\n");
    //         }
    //         
    //         content.Append("\n");
    //         
    //         content.Append("- 소모된 아이템\n");
    //         
    //         foreach (var VARIABLE in this.spentItems) {
    //             content.Append($"{VARIABLE.Key}: {VARIABLE.Value}\n");
    //         }
    //     }
    //     else {
    //        content.Append("- 결과\n");
    //        content.Append("사냥감을 잡을 마땅한 도구가 없어 놓치고 말았다.\n");
    //        content.Append("도구 제작은 '인벤토리' 메뉴에서 할 수 있다.\n");
    //        content.Append("우선 제작에 필요한 재료를 모아보자.\n");
    //     }
    //
    //     return (title, content.ToString());
    // }
}
