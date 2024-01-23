using System.Text;
using UnityEngine;

public class PlayerSearchEventInDanger : MonoBehaviour, IPlayerSearchEvent {
    public float Weight { get; set; }

    private StringBuilder resultText;
        
    
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
        var effect = Player.Instance.StatusEffect[statusEffectType.EXHAUSTION];
        var huntingTool = Player.Instance.Inventory[itemType.HUNTING_TOOL];
        int value = 1;
        
        effect.Event();
        this.resultText.Clear();
        
        if (huntingTool.Count > 0) {
            huntingTool.ItemUse(value);

            // UI Text; Result
            this.resultText.Append("- 결과\n");
            this.resultText.Append("탐색 도중 맹수를 만나 가까스로 탈출했다.\n");
            this.resultText.Append("사냥 도구를 가지고 있었던 것이 천만다행이었다.\n");
            this.resultText.Append("사투를 벌이면서 기진맥진해졌다. 휴식이 절실하다.\n");
            
            this.resultText.Append("\n");
            
            // UI Text; Status
            this.resultText.Append("- 스테이터스 잔여량\n");
            this.resultText.Append($"체력: {Player.Instance.Status[statusType.STAMINA]}%\n");
            this.resultText.Append($"체온: {Player.Instance.Status[statusType.BODY_HEAT]}%\n");
            this.resultText.Append($"수분: {Player.Instance.Status[statusType.HYDRATION]}%\n");
            this.resultText.Append($"열량: {Player.Instance.Status[statusType.CALORIES]}%\n");

            this.resultText.Append("\n");
            
            // UI Text; Items 
            this.resultText.Append("- 획득한 아이템\n");
            this.resultText.Append("없음\n");

            this.resultText.Append("\n");

            this.resultText.Append("- 소모한 아이템\n");
            this.resultText.Append($"{huntingTool.ItemName}: {value}개\n");
        }
        else {
            effect = Player.Instance.StatusEffect[statusEffectType.INJURED];
            effect.Event();

            // UI Text; Result
            this.resultText.Append("- 결과\n");
            this.resultText.Append("탐색 도중 맹수를 만나 가까스로 탈출했다.\n");
            this.resultText.Append("마땅한 도구가 없어 큰 부상을 입고 말았다.\n");
            this.resultText.Append($"부상 회복까지 {effect.DurationTerm / 500}일({effect.DurationTerm}텀)이 걸린다.\n");
            this.resultText.Append("부상 회복이 먼저다. 의약품을 만들고 휴식을 취하자.\n");
            
            this.resultText.Append("\n");
            
            // UI Text; Status
            this.resultText.Append("- 스테이터스 잔여량\n");
            this.resultText.Append($"체력: {Player.Instance.Status[statusType.STAMINA]}%\n");
            this.resultText.Append($"체온: {Player.Instance.Status[statusType.BODY_HEAT]}%\n");
            this.resultText.Append($"수분: {Player.Instance.Status[statusType.HYDRATION]}%\n");
            this.resultText.Append($"열량: {Player.Instance.Status[statusType.CALORIES]}%\n");

            this.resultText.Append("\n");

            // UI Text; Items
            this.resultText.Append("- 획득한 아이템\n");
            this.resultText.Append("없음\n");

            this.resultText.Append("\n");
            
            this.resultText.Append("- 소모한 아이템\n");
            this.resultText.Append("없음\n");
        }
        
        return this.resultText.ToString();
    }
}