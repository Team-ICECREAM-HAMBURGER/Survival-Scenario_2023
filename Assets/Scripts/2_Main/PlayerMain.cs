using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerMain : MonoBehaviour {
    [SerializeField] private Button moveButton;
    [SerializeField] private Button searchButton;
    [SerializeField] private Button fireButton;
    [SerializeField] private Button shelterButton;
    [SerializeField] private Button rainGutter;

    private string warningMessageContent;
    private string warningMessageTitle;
        
    
    private void Init() {
        this.moveButton.onClick.AddListener(Move);
        this.searchButton.onClick.AddListener(Search);
        this.fireButton.onClick.AddListener(Fire);
        this.shelterButton.onClick.AddListener(Shelter);
        this.rainGutter.onClick.AddListener(RainGutter);

        // Background Init
        switch (GameInfo.Instance.CurrentDayNight) {
            case dayNightType.DAY:
                GameBackground.instance.BackgroundChange("Background Day");
                break;
            
            case dayNightType.NIGHT:
                GameBackground.instance.BackgroundChange("Background Night");
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
    }

    private bool CanMove() {
        // 이동하기 조건
        /*
         * 모든 스테이터스가 25% 이상.
         * 부상을 입지 않음.
        */

        float status = 50f;
        
        // TODO: 조건 불충족으로 인해 다른 지역 이동 불가. -> 경고창 출력
        if (!Player.Instance.StatusCheck(status)) {
            this.warningMessageTitle = "스테이터스가 충분하지 않음";
            this.warningMessageContent = "다른 지역으로 이동할 수 있을만큼 스테이터스가 충분하지 않다.\n" +
                                         $"다른 지역으로 이동하기 위해서는 최소한 모든 스테이터스가 {status}% 이상이어야 한다.\n";
            
            GameWarningView.OnWarningMessageEvent(this.warningMessageTitle, this.warningMessageContent);
            
            return false;
        }
        
        if (Player.Instance.CurrentStatusEffect.ContainsKey(statusEffectType.INJURED)) {
            this.warningMessageTitle = "현재 부상을 입었음";
            this.warningMessageContent = "부상을 입은 상태에서는 스테이터스 소모량이 증가하며, 다른 지역으로 이동할 수 없다.\n" +
                                         $"부상은 휴식과 잠을 통해 빠르게 회복할 수 있다. 아플 때는 우선 쉬어주자.\n";
            
            GameWarningView.OnWarningMessageEvent(this.warningMessageTitle, this.warningMessageContent);
            
            return false;
        }

        return true;
    }
    
    private void Search() {
        if (CanSearch()) {            
            GameInfo.OnTimeUpdateEvent(1);
            PlayerSearch.OnSearchEvent();
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
            
            GameWarningView.OnWarningMessageEvent(this.warningMessageTitle, this.warningMessageContent);
            
            return false;
        }

        if (GameInfo.Instance.CurrentDayNight == dayNightType.NIGHT && Player.Instance.Inventory[itemType.TORCH].Count < 1) {
            this.warningMessageTitle = "횃불이 준비되지 않음";
            this.warningMessageContent = "빛이 없는 야간에 탐색을 나서기 위해서는 횃불이 필요하다.\n " +
                                         "횃불은 인벤토리에서 제작할 수 있다. 우선 제작에 필요한 재료를 모아보자.\n";
            
            GameWarningView.OnWarningMessageEvent(this.warningMessageTitle, this.warningMessageContent);

            return false;
        }

        return true;
    }

    private void Fire() {
        if (CanFire()) {
            GameCanvasControl.OnCanvasChangeEvent("Canvas Fire");
            GameCanvasControl.OnCanvasOnEvent("Canvas Info");
        }
    }

    private bool CanFire() {
        // 불 피우기 조건
        /*
         * 점화 도구 1개, 불쏘시개 3개, 나무 1개 이상.
         * 날씨 맑음: 성공 확률 70%, 날씨 비: 성공 확률 30%, 날씨 눈: 성공 확률 30%
         * 성공 여부와 상관 없이 재료 소비.
        */

        if (GameInfo.Instance.IsFireInstalled) {
            return false;
        }

        if (!(Player.Instance.Inventory[itemType.FIRE_TOOL].Count >= 1) && 
            !(Player.Instance.Inventory[itemType.KINDLING].Count >= 3) &&
            !(Player.Instance.Inventory[itemType.WOOD].Count >= 1)) {
            return false;
        }

        switch (GameInfo.Instance.CurrentWeather) {
            case weatherType.SUNNY :
                return Random.Range(0, 10) > 3; // 70%

            case weatherType.RAIN :
                return Random.Range(0, 10) > 7; // 30%

            case weatherType.SNOW :
                return Random.Range(0, 10) > 7; // 30%

            default:
                return true;
        }
    }
    
    // Constructions
    private void Shelter() {
        GameCanvasControl.OnCanvasChangeEvent("Canvas Shelter");
        GameCanvasControl.OnCanvasOnEvent("Canvas Info");
    }

    private void RainGutter() {
        GameCanvasControl.OnCanvasChangeEvent("Canvas RainGutter");
        GameCanvasControl.OnCanvasOnEvent("Canvas Info");
    }
}