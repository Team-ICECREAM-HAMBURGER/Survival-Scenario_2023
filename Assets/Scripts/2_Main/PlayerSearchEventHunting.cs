using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PlayerSearchEventHunting : MonoBehaviour, IPlayerSearchEvent {
    public float Weight { get; set; }

    private readonly StringBuilder huntingResult;
    
    
    public PlayerSearchEventHunting(float weight) {
        this.Weight = weight;
        this.huntingResult = new StringBuilder();
    }
    
    public void Event() {
        // Debug
        Debug.Log("HuntingEvent");
        
        PlayerSearchResultView.OnSearchResultUIHunting(Hunting());
    }

    private string Hunting() {
        if (Player.Instance.Inventory[itemType.HUNTING_TOOL].Count >= 1) {
            int count = 0;
            
            // Item Use; Hunting Tool
            this.huntingResult.Append(Player.Instance.Inventory[itemType.HUNTING_TOOL].ItemUse());
            
            // Item Acquire; Raw Meat
            this.huntingResult.Append(Player.Instance.Inventory[itemType.RAW_MEAT].ItemAcquire());
        }
        else {
            this.huntingResult.Append("마땅한 도구가 없어 사냥감을 놓치고 말았다.");
            this.huntingResult.Append("도구 제작은 '인벤토리' 메뉴에서 할 수 있다.");
            this.huntingResult.Append("우선 제작에 필요한 재료를 모아보자.");
        }
        
        return huntingResult.ToString();
    }
}