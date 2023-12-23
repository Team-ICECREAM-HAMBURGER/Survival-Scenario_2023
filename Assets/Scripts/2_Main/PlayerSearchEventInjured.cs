using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSearchEventInjured : MonoBehaviour, IPlayerSearchEvent {
    public float Weight { get; set; }

    private readonly StringBuilder resultText; 
    
    
    public PlayerSearchEventInjured(float weight) {
        this.Weight = weight;
        this.resultText = new StringBuilder();
    }

    public void Event() {
        // Debug
        Debug.Log("InjuredEvent");
        
        // Event
        PlayerSearchResultView.OnSearchResultUIInjured(Injured());
    }

    private string Injured() {
        this.resultText.Clear();
        
        var effect = Player.Instance.StatusEffect[statusEffectType.INJURED];
        
        effect.Event();

        this.resultText.Append($"부상이 회복될 때까지 {effect.DurationTerm / 500}일({effect.DurationTerm}텀)이 걸린다.\n");
        this.resultText.Append("그 동안은 다른 지역으로 이동할 수 없으며, 상태 수치의 소모량이 2배 증가한다.\n");
        
        return this.resultText.ToString();
    }
}