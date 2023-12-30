using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PlayerSearchEventInDanger : MonoBehaviour, IPlayerSearchEvent {
    public float Weight { get; set; }

    private string resultText;
        
    
    public PlayerSearchEventInDanger(float weight) {
        this.Weight = weight;
    }
    
    public void Event() {
        // Debug
        Debug.Log("InDangerEvent");
        
        // Event
        PlayerSearchResultView.OnSearchResultUIInDanger(InDanger());
    }

    private string InDanger() {
        var effect = Player.Instance.StatusEffect[statusEffectType.EXHAUSTION];
        int value = 1;
        
        effect.Event();
        
        if (Player.Instance.Inventory[itemType.HUNTING_TOOL].ItemUse(value)) {
            this.resultText = $"무사히 탈출에 성공했지만, 사냥 도구 {value}개를 잃고 체력을 모두 소모해 탈진 상태가 되었다.\n";
        }
        else {
            effect = Player.Instance.StatusEffect[statusEffectType.INJURED];
            effect.Event();

            this.resultText = "간신히 도망쳤지만, 체력을 모두 소모해 탈진 상태가 되었다.\n" +
                              "마땅한 도구가 없어 저항을 하던 도중 부상을 입고 말았다.\n" +
                              $"부상이 회복될 때까지 {effect.DurationTerm / 500}일({effect.DurationTerm}텀)이 걸린다.\n" +
                              "그 동안은 다른 지역으로 이동할 수 없으며, 상태 수치의 소모량이 2배 증가한다.\n";
        }
        
        return this.resultText;
    }
}