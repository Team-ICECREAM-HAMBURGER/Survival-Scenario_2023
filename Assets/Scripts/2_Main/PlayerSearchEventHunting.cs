using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSearchEventHunting : MonoBehaviour, IPlayerSearchEvent {
    public float Weight { get; set; }

    private Dictionary<string, int> resultItems; 
        
    
    public playerSearchEventHunting(float weight) {
        this.Weight = weight;
        this.resultItems = new Dictionary<string, int>() {
            
        };
    }
    
    public void Event() {
        // Debug
        Debug.Log("HuntingEvent");
        
        PlayerSearchResultView.Instance.Hunting((Hunting()) ? this.resultItems : null);
    }

    private bool Hunting() {
        this.resultItems.Clear();
        
        if (Player.instance.inventory[itemType.HUNTING_TOOL].Count >= 1) {
            int count = 0;
            
            // Item Acquire
            count = Player.instance.inventory[itemType.RAW_MEAT].Count;
            this.resultItems.Add(
                Player.instance.inventory[itemType.RAW_MEAT].ItemName, 
                (Player.instance.inventory[itemType.RAW_MEAT].ItemAcquire() - count));
            
            // Item Use
            count = Player.instance.inventory[itemType.HUNTING_TOOL].Count;
            this.resultItems.Add(
                Player.instance.inventory[itemType.HUNTING_TOOL].ItemName, 
                (Player.instance.inventory[itemType.HUNTING_TOOL].ItemUse() - count));
            
            return true;
        }
        else {
            // TODO: 사냥 도구가 없어서 사냥을 할 수 없는 경우에는 어떻게 해야 하는가?
            // 1: "사냥감을 발견했으나, 도구가 없어서 놓쳤다." 메시지 출력
            
            return false;
        }
    }
}