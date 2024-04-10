using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class GameRandomEventSearchHunting : MonoBehaviour, IGameRandomEvent {   // Presenter
    public float Weight { get; private set; }

    private string title;
    private StringBuilder content;
    private List<IItem> itemList;
    private Dictionary<string, int> itemDic;
    
    
    private void Init() {
        this.Weight = 5f;
        this.itemList = new();
        this.itemDic = new();
        this.content = new();
    }

    private void Awake() {
        Init();
    }
    
    public void Event() {
        // TODO: 사냥 이벤트 제작 -> 사냥 아이템 소지 여부에 따라 성공 여부가 달라짐 -> 고기, 가죽 아이템 획득
        Debug.Log("HuntingEvent");

        if (Player.Instance.InventoryCheck("사냥 도구")) {
            Player.Instance.InventoryUpdate("사냥 도구", -1);

            
        }
    }

    public void EventResult() {
        // TODO: 사냥 성공 여부에 따라 결과 텍스트가 달라짐
        this.title = "탐색 결과";

        this.content.Clear();
    }
    
// private (string title, StringBuilder content) HuntingResult() {
//     this.content.Clear();
//     
//     this.content.Append("- 결과\n");
//     this.content.Append("끈질긴 추격전 끝에 사냥에 성공했다.\n");
//
//     /*
//         this.resultText.Append("- 결과\n");
//         this.resultText.Append("사냥감을 잡을 마땅한 도구가 없어 놓치고 말았다.\n");
//         this.resultText.Append("도구 제작은 '인벤토리' 메뉴에서 할 수 있다.\n");
//         this.resultText.Append("우선 제작에 필요한 재료를 모아보자.\n");
//     */
//     
//     this.content.Append("\n");
//     
//     this.content.Append("- 스테이터스 잔여량\n");
//     this.content.Append($"체력: %\n");
//     this.content.Append($"체온: %\n");
//     this.content.Append($"수분: %\n");
//     this.content.Append($"열량: %\n");
//     
//     this.content.Append("\n");
//     
//     this.content.Append("- 획득한 아이템\n");
//     
//     this.content.Append("\n");
//
//     this.content.Append("- 소모된 아이템\n");
//     
//     
//     return (this.title, this.content);
// }
}
