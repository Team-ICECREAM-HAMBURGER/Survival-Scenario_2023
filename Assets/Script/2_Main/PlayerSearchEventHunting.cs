using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PlayerSearchEventHunting : MonoBehaviour, IPlayerSearchEvent {
    public float Weight { get; set; }

    private string resultText;
    
    
    public PlayerSearchEventHunting(float weight) {
        this.Weight = weight;
    }
    
    public void Event() {
        // Debug
        Debug.Log("HuntingEvent");
        
        PlayerSearchResultView.OnSearchResultUIHunting(Hunting());
    }

    private string Hunting() {
        if (Player.Instance.Inventory[itemType.HUNTING_TOOL].Count >= 1) {
            int usedValue = 1;

            var huntingTool = Player.Instance.Inventory[itemType.HUNTING_TOOL];
            huntingTool.ItemUse(usedValue);
            
            int acquiredValue = Player.Instance.Inventory[itemType.RAW_MEAT].ItemAcquire();
            this.resultText = $"끈질긴 추격전 끝에 사냥에 성공했다. 사냥 도구 {usedValue}개가 소모되었다.\n" +
                              $"잡은 사냥감을 손질해서 생고기 {acquiredValue}개를 가지고 돌아왔다.\n";
        }
        else {
            this.resultText = "마땅한 도구가 없어 사냥감을 놓치고 말았다.\n" + 
                              "도구 제작은 '인벤토리' 메뉴에서 할 수 있다.\n" +
                              "우선 제작에 필요한 재료를 모아보자.\n";
        }

        return resultText;
    }
}