using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PlayerSearchEventInDanger : MonoBehaviour, IPlayerSearchEvent {
    public float Weight { get; set; }

    private readonly StringBuilder resultText;
        
    
    public PlayerSearchEventInDanger(float weight) {
        this.Weight = weight;
        this.resultText = new StringBuilder();
    }
    
    public void Event() {
        // Debug
        Debug.Log("InDangerEvent");
        
        // Event
        PlayerSearchResultView.OnSearchResultUIInDanger(InDanger());
    }

    private string InDanger() {
        this.resultText.Clear();
        
        var effect = Player.Instance.StatusEffect[statusEffectType.EXHAUSTION];

        effect.Event();
        
        if (Player.Instance.Inventory[itemType.HUNTING_TOOL].ItemUse()) {
            this.resultText.Append("무사히 탈출에 성공했지만, 사냥 도구 1개를 잃고 체력을 모두 소모해 탈진 상태가 되었다.");
        }
        else {
            effect = Player.Instance.StatusEffect[statusEffectType.INJURED];
            
            effect.Event();
            
            this.resultText.Append("간신히 도망쳤지만, 체력을 모두 소모해 탈진 상태가 되었다.\n");
            this.resultText.Append("마땅한 도구가 없어 저항을 하던 도중 부상을 입고 말았다.\n");
            this.resultText.Append($"부상이 회복될 때까지 {effect.DurationTerm / 500}일({effect.DurationTerm}텀)이 걸린다.\n");
            this.resultText.Append("그 동안은 다른 지역으로 이동할 수 없으며, 상태 수치의 소모량이 2배 증가한다.\n");
        }
        
        return this.resultText.ToString();
    }
}