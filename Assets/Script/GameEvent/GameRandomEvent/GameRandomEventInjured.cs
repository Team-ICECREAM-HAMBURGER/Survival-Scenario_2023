using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GameRandomEventInjured : MonoBehaviour, IGameRandomEvent {
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
    
    public (string, string) Event() {
        Debug.Log("InjuredEvent");

        EventResult();

        return (this.title, this.content.ToString());
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

        this.content.Append("부상 상태 이상 효과가 적용됨.\n");
    }
}