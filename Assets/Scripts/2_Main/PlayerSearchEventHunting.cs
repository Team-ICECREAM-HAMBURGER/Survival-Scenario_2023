using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSearchEventHunting : MonoBehaviour, IPlayerSearchEvent {
    public float Weight { get; set; }
    
    
    public playerSearchEventHunting(float weight) {
        this.Weight = weight;
    }
    
    public void Event() {
        // Debug
        Debug.Log("HuntingEvent");

        if (player.instance.inventory[itemType.HUNTING_TOOL].Count >= 1) {
            Debug.Log("Before: " + player.instance.inventory[itemType.HUNTING_TOOL].Count);

            // Meat Get
            player.instance.inventory[itemType.RAW_MEAT].ItemAcquire();
        
            // Player Status Update
            player.instance.StatusUpdate(20, 10, 10, 10);
            
            //Item Use
            player.instance.inventory[itemType.HUNTING_TOOL].ItemUse();
            
            Debug.Log("After: " + player.instance.inventory[itemType.HUNTING_TOOL].Count);

        }
        else {
            // TODO: 사냥 도구가 없어서 사냥을 할 수 없는 경우에는 어떻게 해야 하는가?
            // 1: "사냥감을 발견했으나, 도구가 없어서 놓쳤다." 메시지 출력
            // 2: 아이템 노획으로 노선 변경
        }
    }
}
