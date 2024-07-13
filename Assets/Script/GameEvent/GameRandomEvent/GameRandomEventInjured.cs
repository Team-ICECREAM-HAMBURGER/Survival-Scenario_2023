using System;
using System.Text;
using UnityEngine;

public class GameRandomEventInjured : GameRandomEvent {
    public override void Init() {
        this.Percent = 5;
    }
    
    public override void Event() {
        // Debug
        Debug.Log("InjuredEvent");
        
        // Player Status Effect Add
        PlayerStatusEffectManager.Instance.StatusEffectAdd(GameControlType.StatusEffect.INJURED);
    }

    public override (string, string) EventResult() {
        var title = String.Empty;
        var content = new StringBuilder();
        
        title = "부상을 입음";
        content.Clear();
        
        content.Append("- 결과\n");
        content.Append("탐색 도중 부주의로 인해 부상을 입고 말았다.\n");
        content.Append("이동보다는 부상 회복이 우선이다.\n");
        content.Append("휴식을 취하며 의약품을 구해보자.\n");
        
        return (title, content.ToString());
    }
}