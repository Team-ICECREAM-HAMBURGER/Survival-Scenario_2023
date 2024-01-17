using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerOutside : MonoBehaviour {
    [SerializeField] private Button moveButton;
    [SerializeField] private Button searchButton;
    [SerializeField] private Button fireButton;
    [SerializeField] private Button rainGutter;

    private string warningMessageContent;
    private string warningMessageTitle;
    
    
    private void Init() {
        this.moveButton.onClick.AddListener(Move);
        this.searchButton.onClick.AddListener(Search);
        this.fireButton.onClick.AddListener(Fire);
        this.rainGutter.onClick.AddListener(RainGutter);

        // Background Init
        switch (GameInfo.Instance.CurrentDayNight) {
            case dayNightType.DAY:
                GamePanelControl.OnGamePanelOffEvent("Background Night");
                GamePanelControl.OnGamePanelOnEvent("Background Day");
                break;
            
            case dayNightType.NIGHT:
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
            GameWarningView.OnWarningMessageEvent(this.warningMessageTitle, this.warningMessageContent);
        }
    }

    private bool CanMove() {
        // 이동하기 조건
        /*
         * 모든 스테이터스가 25% 이상.
         * 부상을 입지 않음.
        */

        float status = 50f;
        
        if (!Player.Instance.StatusCheck(status)) {
            this.warningMessageTitle = "스테이터스가 충분하지 않음";
            this.warningMessageContent = "다른 지역으로 이동할 수 있을만큼 스테이터스가 충분하지 않다.\n" +
                                         $"다른 지역으로 이동하기 위해서는 최소한 모든 스테이터스가 {status}% 이상이어야 한다.\n";
            
            return false;
        }
        
        if (Player.Instance.CurrentStatusEffect.ContainsKey(statusEffectType.INJURED)) {
            this.warningMessageTitle = "현재 부상을 입었음";
            this.warningMessageContent = "부상을 입은 상태에서는 스테이터스 소모량이 증가하며, 다른 지역으로 이동할 수 없다.\n" +
                                         "부상은 휴식과 잠을 통해 빠르게 회복할 수 있다. 아플 때는 우선 쉬어주자.\n";
            
            return false;
        }

        return true;
    }
    
    private void Search() {
        if (CanSearch()) {            
            GameInfo.OnTimeUpdateEvent(1);
            PlayerSearch.OnSearchEvent();
        }
        else {
            GameWarningView.OnWarningMessageEvent(this.warningMessageTitle, this.warningMessageContent);
        }
    }

    private bool CanSearch() {
        // 탐색하기 조건
        /*
         * 체력 20% 이상, 체온 10% 이상, 수분 10% 이상 허기 10% 이상.
         * 밤일 경우, '횃불' 아이템 1개 이상.
        */

        float stamina = 20f;
        float bodyHeat = 15f;
        float hydration = 5f;
        float calories = 10f;
        
        if (!Player.Instance.StatusCheck(stamina, bodyHeat, hydration, calories)) {
            this.warningMessageTitle = "스테이터스가 너무 낮음";
            this.warningMessageContent = "탐색에 나설만큼 스테이터스가 충분하지 않다.\n" +
                                         $"탐색에는 최소한 체력 {stamina}%, 체온 {bodyHeat}%, 수분 {hydration}%, 허기 {calories}% 이상이 필요하다.\n";
            
            return false;
        }

        if (GameInfo.Instance.CurrentDayNight == dayNightType.NIGHT && Player.Instance.Inventory[itemType.TORCH].Count < 1) {
            this.warningMessageTitle = "횃불이 준비되지 않음";
            this.warningMessageContent = "빛이 없는 야간에 탐색을 나서기 위해서는 횃불이 필요하다.\n " +
                                         "횃불은 인벤토리에서 제작할 수 있다. 우선 제작에 필요한 재료를 모아보자.\n";
            
            return false;
        }

        return true;
    }

    private void Fire() {
        if (GameInfo.Instance.IsFireInstalled) {    // 이미 불이 피워져 있음.
            GameCanvasControl.OnCanvasChangeEvent("Canvas Fire");
            GameCanvasControl.OnCanvasOnEvent("Canvas Information");
            return;
        }
        
        if (CanFire()) {
            GameCanvasControl.OnCanvasChangeEvent("Canvas Fire");
            
            GameInfo.OnTimeUpdateEvent(1);
            PlayerFire.OnMakingFireEvent();
        }
        else {
            GameWarningView.OnWarningMessageEvent(this.warningMessageTitle, this.warningMessageContent);
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

        int fireTool = 1;
        int kindling = 2;
        int wood = 3;

        float stamina = 15f;
        float bodyHeat = 10f;
        float hydration = 8f;
        float calories = 9f;
        
        if (!Player.Instance.StatusCheck(stamina, bodyHeat, hydration, calories)) {
            this.warningMessageTitle = "스테이터스가 너무 낮음";
            this.warningMessageContent = "불을 피울 수 있을만큼 스테이터스가 충분하지 않다.\n" +
                                         $"불을 피우기 위해서는 최소한 체력 {stamina}%, 체온 {bodyHeat}%, 수분 {hydration}%, 허기 {calories}% 이상이 필요하다.\n";

            return false;
        }
        
        if (!(Player.Instance.Inventory[itemType.FIRE_TOOL].Count >= fireTool) || 
            !(Player.Instance.Inventory[itemType.KINDLING].Count >= kindling) ||
            !(Player.Instance.Inventory[itemType.WOOD].Count >= wood)) {    // 불을 피울 재료가 부족함.
            this.warningMessageTitle = "재료가 준비되지 않음";
            this.warningMessageContent = "불을 피울 재료가 모두 준비되지 않았다.\n" +
                                         $"불을 피우기 위해서는 점화 도구 {fireTool}개, 불쏘시개 {kindling}개, 나무 {wood}개 이상이 필요하다.\n" +
                                         "우선 주변을 탐색하여 제작에 필요한 재료를 모아보자.\n";
            
            return false;
        }
        
        return true;
    }
    
    private void RainGutter() {
        GameCanvasControl.OnCanvasChangeEvent("Canvas Rain Gutter");
        GameCanvasControl.OnCanvasOnEvent("Canvas Information");
    }
}