using System.Text;
using UnityEngine;

public class PlayerSearchEventHunting : MonoBehaviour, IPlayerSearchEvent {
    public float Weight { get; set; }

    private readonly StringBuilder resultText;
    
    
    public PlayerSearchEventHunting(float weight) {
        this.Weight = weight;
        this.resultText = new StringBuilder();
    }
    
    public void Event() {
        // Debug
        Debug.Log("HuntingEvent");
        
        PlayerSearchResultView.OnSearchResultUIHunting(Hunting());
    }

    private string Hunting() {
        this.resultText.Clear();
        
        if (Player.Instance.Inventory[ItemType.HUNTING_TOOL].Count >= 1) {
            var acquiredItem = Player.Instance.Inventory[ItemType.RAW_MEAT];
            var huntingTool = Player.Instance.Inventory[ItemType.HUNTING_TOOL];
            
            var usedValue = 1;
            var acquiredValue = acquiredItem.ItemAcquire();
            
            huntingTool.ItemUse(usedValue);
            
            // UI Text; Result
            this.resultText.Append("- 결과\n");
            this.resultText.Append("끈질긴 추격전 끝에 사냥에 성공했다.\n");
            
            this.resultText.Append("\n");
            
            // UI Text; Status
            this.resultText.Append("- 스테이터스 잔여량\n");
            this.resultText.Append($"체력: {Player.Instance.Status[StatusType.STAMINA]}%\n");
            this.resultText.Append($"체온: {Player.Instance.Status[StatusType.BODY_HEAT]}%\n");
            this.resultText.Append($"수분: {Player.Instance.Status[StatusType.HYDRATION]}%\n");
            this.resultText.Append($"열량: {Player.Instance.Status[StatusType.CALORIES]}%\n");
            
            this.resultText.Append("\n");
            
            // UI Text; Items
            this.resultText.Append("- 획득한 아이템\n");
            this.resultText.Append($"{acquiredItem.ItemName}: {acquiredValue}개\n");
            
            this.resultText.Append("\n");
            
            // UI Text; Items
            this.resultText.Append("- 소모된 아이템\n");
            this.resultText.Append($"{huntingTool.ItemName}: {usedValue}개\n");
        }
        else {
            // UI Text; Result
            this.resultText.Append("- 결과\n");
            this.resultText.Append("사냥감을 잡을 마땅한 도구가 없어 놓치고 말았다.\n");
            this.resultText.Append("도구 제작은 '인벤토리' 메뉴에서 할 수 있다.\n");
            this.resultText.Append("우선 제작에 필요한 재료를 모아보자.\n");
            
            this.resultText.Append("\n");
            
            // UI Text; Status
            this.resultText.Append("- 스테이터스 잔여량\n");
            this.resultText.Append($"체력: {Player.Instance.Status[StatusType.STAMINA]}%\n");
            this.resultText.Append($"체온: {Player.Instance.Status[StatusType.BODY_HEAT]}%\n");
            this.resultText.Append($"수분: {Player.Instance.Status[StatusType.HYDRATION]}%\n");
            this.resultText.Append($"열량: {Player.Instance.Status[StatusType.CALORIES]}%\n");
            
            this.resultText.Append("\n");
            
            // UI Text; Items
            this.resultText.Append("- 획득한 아이템\n");
            this.resultText.Append("없음\n");
            
            this.resultText.Append("\n");
            
            // UI Text; Items
            this.resultText.Append("- 소모된 아이템\n");
            this.resultText.Append("없음\n");
        }

        return resultText.ToString();
    }
}