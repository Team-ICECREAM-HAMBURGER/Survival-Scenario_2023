using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOutside : MonoBehaviour {
    [Header("UI Buttons")]
    [SerializeField] private Button moveButton;
    [SerializeField] private Button searchButton;
    [SerializeField] private Button fireButton;
    [SerializeField] private Button rainGutterButton;
    private string warningMessageTitle;
    private StringBuilder warningMessageContent;

    
    private void Init() {
        this.moveButton.onClick.AddListener(Move);
        this.searchButton.onClick.AddListener(Search);
        this.fireButton.onClick.AddListener(Fire);
        this.rainGutterButton.onClick.AddListener(RainGutter);

        this.warningMessageContent = new StringBuilder();
        
        // TODO: Background Change -> DayNight Dictionary
        switch (GameInfoControl.Instance.CurrentDayNight) {
            case DayNightType.DAY:
                GamePanelControl.OnGamePanelOffEvent("Background Night");
                GamePanelControl.OnGamePanelOnEvent("Background Day");
                break;
            
            case DayNightType.NIGHT:
                GamePanelControl.OnGamePanelOffEvent("Background Day");
                GamePanelControl.OnGamePanelOnEvent("Background Night");
                break;
        }
    }

    private void Start() {
        Init();
    }

    private void Move() {
        if (CanMove()) {
            GameCanvasControl.OnCanvasChangeEvent("Canvas Move");
        }
        else {
            GameWarningView.OnWarningMessageEvent(this.warningMessageTitle, this.warningMessageContent.ToString());
        }
    }

    private bool CanMove() {
        // 이동하기 조건
        /*
         * 모든 스테이터스가 25% 이상.
         * 부상을 입지 않음.
        */
        
        var status = 50f;

        this.warningMessageContent.Clear();
        
        if (Player.Instance.StatusEffectCheck(StatusEffectType.INJURED)) {
            this.warningMessageTitle = "부상을 입음";
            
            this.warningMessageContent.Append("부상을 입은 상태에서는 다른 지역으로 이동할 수 없다.\n");
            this.warningMessageContent.Append("부상을 회복하기 위해서는 휴식과 잠이 중요하다.\n");
            this.warningMessageContent.Append("만약 의료품이 있다면 더욱 빠르게 회복이 가능하다.\n");
            
            return false;
        }
        
        if (!Player.Instance.StatusCheck(status)) {
            this.warningMessageTitle = "스테이터스가 너무 낮음";

            this.warningMessageContent.Append("다른 지역으로 이동할 수 있을만큼 스테이터스가 충분하지 않다.\n");
            this.warningMessageContent.Append("스테이터스는 음식, 물, 휴식 등으로 회복할 수 있다.\n");
            
            this.warningMessageContent.Append("\n");
            
            this.warningMessageContent.Append("- 스테이터스 요구 사항\n");
            this.warningMessageContent.Append($"체력: {status}% 이상\n");
            this.warningMessageContent.Append($"체온: {status}% 이상\n");
            this.warningMessageContent.Append($"수분: {status}% 이상\n");
            this.warningMessageContent.Append($"허기: {status}% 이상\n");
            
            return false;
        }

        return true;
    }
    
    private void Search() {
        if (CanSearch()) {            
            PlayerSearch.OnSearchEvent();
        }
        else {
            GameWarningView.OnWarningMessageEvent(this.warningMessageTitle, this.warningMessageContent.ToString());
        }
    }

    private bool CanSearch() {
        // 탐색하기 조건
        /*
         * 체력 20% 이상, 체온 10% 이상, 수분 10% 이상 허기 10% 이상.
         * 밤일 경우, '횃불' 아이템 1개 이상.
        */

        var stamina = 20f;
        var bodyHeat = 15f;
        var hydration = 5f;
        var calories = 10f;

        this.warningMessageContent.Clear();
        
        if (GameInfoControl.Instance.CurrentDayNight == DayNightType.NIGHT && Player.Instance.Inventory[ItemType.TORCH].Count < 1) {
            this.warningMessageTitle = "횃불이 없음";
            
            this.warningMessageContent.Append("빛이 없는 야간에 탐색을 나서기 위해서는 횃불이 필요하다.\n");
            this.warningMessageContent.Append("횃불은 인벤토리에서 제작할 수 있다. 제작에 필요한 재료를 확인해보자.\n");
            
            return false;
        }
        
        if (!Player.Instance.StatusCheck(stamina, bodyHeat, hydration, calories)) {
            this.warningMessageTitle = "스테이터스가 너무 낮음";

            this.warningMessageContent.Append("탐색에 나설만큼 스테이터스가 충분하지 않다.\n");
            this.warningMessageContent.Append("스테이터스는 음식, 물, 휴식 등으로 회복할 수 있다.\n");

            this.warningMessageContent.Append("\n");
            
            this.warningMessageContent.Append("- 스테이터스 요구 사항\n");
            this.warningMessageContent.Append($"체력: {stamina}% 이상\n");
            this.warningMessageContent.Append($"체온: {bodyHeat}% 이상\n");
            this.warningMessageContent.Append($"수분: {hydration}% 이상\n");
            this.warningMessageContent.Append($"허기: {calories}% 이상\n");
            
            return false;
        }
        
        return true;
    }

    private void Fire() {
        if (CanFire()) {
            PlayerFire.OnMakingFireEvent();
        }
        else {
            GameWarningView.OnWarningMessageEvent(this.warningMessageTitle, this.warningMessageContent.ToString());
        }
    }

    private bool CanFire() {
        // 불 피우기 조건
        /*
         * 점화 도구 1개, 불쏘시개 2개, 나무 3개 이상.
         * 날씨 맑음: 성공 확률 70%, 날씨 비: 성공 확률 30%, 날씨 눈: 성공 확률 30%
         * 체력 15% 소모, 체온 10% 소모, 수분 8% 소모, 허기 9% 소모
         * 성공 여부와 상관 없이 재료 소비.
        */

        var fireTool = 1;
        var kindling = 2;
        var wood = 3;

        var stamina = 15f;
        var bodyHeat = 10f;
        var hydration = 8f;
        var calories = 9f;
        
        this.warningMessageContent.Clear();
        
        if (GameInfoControl.Instance.IsFireInstalled) {
            return true;
        }
        
        if (!(Player.Instance.Inventory[ItemType.FIRE_TOOL].Count >= fireTool) || !(Player.Instance.Inventory[ItemType.KINDLING].Count >= kindling) || !(Player.Instance.Inventory[ItemType.WOOD].Count >= wood)) {    // 불을 피울 재료가 부족함.
            this.warningMessageTitle = "재료가 부족함";
            
            this.warningMessageContent.Append("불을 피울 재료가 모두 준비되지 않았다.\n");
            
            this.warningMessageContent.Append("\n");

            this.warningMessageContent.Append("- 필요한 재료들\n");
            this.warningMessageContent.Append($"점화 도구: {fireTool}개 이상\n");
            this.warningMessageContent.Append($"불쏘시개: {kindling}개 이상\n");
            this.warningMessageContent.Append($"나무: {wood}개 이상\n");
            
            return false;
        }
        
        if (!Player.Instance.StatusCheck(stamina, bodyHeat, hydration, calories)) {
            this.warningMessageTitle = "스테이터스가 너무 낮음";

            this.warningMessageContent.Append("불을 피울 수 있을만큼 스테이터스가 충분하지 않다.\n");
            this.warningMessageContent.Append("스테이터스는 음식, 물, 휴식 등으로 회복할 수 있다.\n");
            
            this.warningMessageContent.Append("\n");
            
            this.warningMessageContent.Append("- 스테이터스 요구 사항\n");
            this.warningMessageContent.Append($"체력: {stamina}% 이상\n");
            this.warningMessageContent.Append($"체온: {bodyHeat}% 이상\n");
            this.warningMessageContent.Append($"수분: {hydration}% 이상\n");
            this.warningMessageContent.Append($"허기: {calories}% 이상\n");
            
            return false;
        }
        
        return true;
    }
    
    private void RainGutter() {
        GameCanvasControl.OnCanvasChangeEvent("Canvas Rain Gutter");
        GameCanvasControl.OnCanvasOnEvent("Canvas Information");
    }
}