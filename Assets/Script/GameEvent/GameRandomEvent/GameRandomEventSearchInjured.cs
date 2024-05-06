using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GameRandomEventSearchInjured : MonoBehaviour, IGameRandomEvent {
    [field: SerializeField] public float Weight { get; set; }

    private string title;
    private StringBuilder content;


    private void Init() {
        //this.Weight = 100f;
        this.content = new();
    }

    private void Awake() {
        Init();
    }
    
    public void Event() {
        Debug.Log("InjuredEvent");

        Player.Instance.StatusEffectMap[GameControlType.StatusEffect.INJURED].Active();
        EventResult();
    }

    public void EventResult() {
        this.title = "탐색 결과";
        this.content.Clear();
        
        this.content.Append("- 결과\n");
        this.content.Append("탐색 도중 부주의로 인해 부상을 입고 말았다.\n");
        this.content.Append("이동보다는 부상 회복이 우선이다. 휴식을 취하며 의약품을 구해보자.\n");

        this.content.Append("\n");
        
        this.content.Append("부상 회복까지 일(텀) 남음.\n");

        this.content.Append("\n");
        
        this.content.Append("- 스테이터스 잔여량\n");
        this.content.Append($"체력: %\n");
        this.content.Append($"체온: %\n");
        this.content.Append($"수분: %\n");
        this.content.Append($"열량: %\n");
        
        this.content.Append("\n");

        this.content.Append("부상 상태 이상 효과가 적용됨.\n");
        
        PlayerBehaviourSearch.OnSearchEventUpdateView(this.title, this.content.ToString());
    }
}