using System;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameRandomEventInjured : MonoBehaviour, IGameRandomEvent {
    [field: SerializeField] public float Weight { get; set; }
    
    
    private void Init() {
    }

    private void Awake() {
        Init();
    }
    
    public void Event() {
        Debug.Log("InjuredEvent");
        
        // TODO : 상태 이상 효과 추가
        PlayerStatusEffectInjured.OnStatusEffectAdd.Invoke();
    }

    public (string, string) EventResult() {
        var title = String.Empty;
        var content = new StringBuilder();
        
        title = "부상을 입음";
        content.Clear();
        
        content.Append("- 결과\n");
        content.Append("탐색 도중 부주의로 인해 부상을 입고 말았다.\n");
        content.Append("이동보다는 부상 회복이 우선이다. 휴식을 취하며 의약품을 구해보자.\n");
        
        return (title, content.ToString());
    }
}