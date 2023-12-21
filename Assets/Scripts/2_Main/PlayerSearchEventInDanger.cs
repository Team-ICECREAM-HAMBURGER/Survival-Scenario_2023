using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PlayerSearchEventInDanger : MonoBehaviour, IPlayerSearchEvent {
    public float Weight { get; set; }

    private readonly StringBuilder inDangerResult;
    
    
    public PlayerSearchEventInDanger(float weight) {
        this.Weight = weight;
        this.inDangerResult = new StringBuilder();
    }
    
    public void Event() {
        // Debug
        Debug.Log("InDangerEvent");
        
        // Event
        PlayerSearchResultView.OnSearchResultUIInDanger(InDanger());
    }

    private string InDanger() {
        var effect = Player.Instance.StatusEffect[statusEffectType.EXHAUSTION];

        effect.Event();
        
        if (Player.Instance.Inventory[itemType.HUNTING_TOOL].ItemUse()) {
            this.inDangerResult.Append("무사히 탈출에 성공했지만, ");
            this.inDangerResult.Append("사냥 도구 1개를 잃고 체력을 모두 소모해 탈진 상태가 되었다.");
        }
        else {
            effect = Player.Instance.StatusEffect[statusEffectType.INJURED];
            
            effect.Event();
            
            this.inDangerResult.Append("간신히 도망쳤지만, ");
            this.inDangerResult.Append("체력을 모두 소모해 탈진 상태가 되었고, ");
            this.inDangerResult.Append("마땅한 도구가 없어 저항을 하던 도중 부상을 입고 말았다.\n");
            this.inDangerResult.Append("부상이 회복될 때까지 ");
            this.inDangerResult.Append($"{effect.DurationTerm / 500}일({effect.DurationTerm}텀)동안 ");
            this.inDangerResult.Append("다른 지역으로 이동할 수 없으며, ");
            this.inDangerResult.Append("상태 수치의 소모량이 2배 증가한다.\n");
        }
        
        return this.inDangerResult.ToString();
    }
}