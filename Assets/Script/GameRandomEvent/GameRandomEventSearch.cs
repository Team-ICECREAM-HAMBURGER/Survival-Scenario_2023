using System.Text;
using UnityEngine;

public class GameRandomEventSearch : MonoBehaviour {
    private string title;
    private StringBuilder content;

    public delegate void SearchEventHandler();
    public static SearchEventHandler OnSearchEventSelect;

    private void Init() {
        this.title = "탐색 결과";
        this.content = new StringBuilder();

        OnSearchEventSelect += RandomEventSelect;
    }

    private void Awake() {
        Init();
    }

    public void RandomEventSelect() {
        
    }
    
    private void FarmingEvent() {
        // Debug
        Debug.Log("FarmingEvent");
        
        // Item Get
    }

    private (string title, string content) FarmingResult() {
        this.content.Clear();
        
        this.content.Append("- 결과\n");
        this.content.Append("주변을 탐색하여 쓸만한 것들을 찾았다.\n");

        this.content.Append("\n");
        
        this.content.Append("- 스테이터스 잔여량\n");
        this.content.Append($"체력: %\n");
        this.content.Append($"체온: %\n");
        this.content.Append($"수분: %\n");
        this.content.Append($"열량: %\n");
        
        this.content.Append("\n");
        
        this.content.Append("- 획득한 아이템\n");
        
        return (this.title, this.content.ToString());
    }
    
    private void HuntingEvent() {
        // Debug
        Debug.Log("HuntingEvent");
    }
    
    private (string title, StringBuilder content) HuntingResult() {
        this.content.Clear();
        
        this.content.Append("- 결과\n");
        this.content.Append("끈질긴 추격전 끝에 사냥에 성공했다.\n");

        /*
            this.resultText.Append("- 결과\n");
            this.resultText.Append("사냥감을 잡을 마땅한 도구가 없어 놓치고 말았다.\n");
            this.resultText.Append("도구 제작은 '인벤토리' 메뉴에서 할 수 있다.\n");
            this.resultText.Append("우선 제작에 필요한 재료를 모아보자.\n");
        */
        
        this.content.Append("\n");
        
        this.content.Append("- 스테이터스 잔여량\n");
        this.content.Append($"체력: %\n");
        this.content.Append($"체온: %\n");
        this.content.Append($"수분: %\n");
        this.content.Append($"열량: %\n");
        
        this.content.Append("\n");
        
        this.content.Append("- 획득한 아이템\n");
        
        this.content.Append("\n");

        this.content.Append("- 소모된 아이템\n");
        
        
        return (this.title, this.content);
    }

    private void InDangerEvent() {
        // Debug
        Debug.Log("InDangerEvent");
    }
    
    private (string title, StringBuilder content) InDangerResult() {
        this.content.Clear();
        
        this.content.Append("- 결과\n");
        this.content.Append("탐색 도중 맹수를 만나 가까스로 탈출했다.\n");
        this.content.Append("사냥 도구를 가지고 있었던 것이 천만다행이었다.\n");
        this.content.Append("사투를 벌이면서 기진맥진해졌다. 휴식이 절실하다.\n");
        
        /*
            this.resultText.Append("- 결과\n");
            this.resultText.Append("탐색 도중 맹수를 만나 가까스로 탈출했다.\n");
            this.resultText.Append("마땅한 도구가 없어 큰 부상을 입고 말았다.\n");
            this.resultText.Append($"부상 회복까지 {day}일({term}텀)이 걸린다.\n");
            this.resultText.Append("부상 회복이 먼저다. 의약품을 만들고 휴식을 취하자.\n");
        */         

        this.content.Append("\n");
        
        this.content.Append("- 스테이터스 잔여량\n");
        this.content.Append($"체력: %\n");
        this.content.Append($"체온: %\n");
        this.content.Append($"수분: %\n");
        this.content.Append($"열량: %\n");
        
        this.content.Append("\n");
        
        this.content.Append("- 획득한 아이템\n");
        this.content.Append("없음\n");

        this.content.Append("\n");

        this.content.Append("- 소모한 아이템\n");
        
        return (this.title, this.content);
    }

    private void InjuredEvent() {
        // Debug
        Debug.Log("Injured");
    }
    
    private (string title, StringBuilder content) InjuredResult() {
        this.content.Clear();
        
        this.content.Append("- 결과\n");
        this.content.Append("탐색 도중 위험에 빠졌다.\n");
        this.content.Append("가까스로 돌아오기는 했지만 부상을 입고 말았다.\n");
        this.content.Append("부상 회복까지 일(텀)이 걸린다.\n");
        this.content.Append("부상 회복이 먼저다. 의약품을 만들고 휴식을 취하자.\n");
        
        this.content.Append("\n");
        
        this.content.Append("- 스테이터스 잔여량\n");
        this.content.Append($"체력: %\n");
        this.content.Append($"체온: %\n");
        this.content.Append($"수분: %\n");
        this.content.Append($"열량: %\n");
        
        this.content.Append("\n");
        
        this.content.Append("- 획득한 아이템\n");
        
        this.content.Append("\n");
        
        this.content.Append("- 소모한 아이템\n");
        this.content.Append("없음\n");
        
        return (this.title, this.content);
    }
}
