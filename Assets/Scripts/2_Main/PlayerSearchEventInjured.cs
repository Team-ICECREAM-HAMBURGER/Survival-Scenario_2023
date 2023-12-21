using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSearchEventInjured : MonoBehaviour, IPlayerSearchEvent {
    public float Weight { get; set; }

    private readonly StringBuilder injuredResult;
    
    
    public PlayerSearchEventInjured(float weight) {
        this.Weight = weight;
        this.injuredResult = new StringBuilder();
    }

    public void Event() {
        // Debug
        Debug.Log("InjuredEvent");
        
        // Event
        PlayerSearchResultView.OnSearchResultUIInjured(Injured());
    }

    private string Injured() {
        var effect = Player.Instance.StatusEffect[statusEffectType.INJURED];
        
        effect.Event();
        
        this.injuredResult.Append("부상이 회복될 때까지 ");
        this.injuredResult.Append($"{effect.DurationTerm / 500}일({effect.DurationTerm}텀)동안 ");
        this.injuredResult.Append("다른 지역으로 이동할 수 없으며, ");
        this.injuredResult.Append("상태 수치의 소모량이 2배 증가한다.\n");
        
        return this.injuredResult.ToString();
    }
}