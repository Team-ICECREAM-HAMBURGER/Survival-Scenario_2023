using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviourOutside : MonoBehaviour, IPlayerBehaviour {
    [Header("UI Buttons")]
    [SerializeField] private Button moveButton;
    [SerializeField] private Button searchButton;
    [SerializeField] private Button fireButton;
    [SerializeField] private Button rainGutterButton;
    
    private string warningMessageTitle;
    private StringBuilder warningMessageContent;
    
    
    private void Init() {
        //this.moveButton.onClick.AddListener(Move);
        //this.searchButton.onClick.AddListener(Search);
        //this.fireButton.onClick.AddListener(Fire);
        this.rainGutterButton.onClick.AddListener(RainGutter);
        
        this.warningMessageContent = new StringBuilder();
        
        // TODO: Background Change -> DayNight Dictionary
    }

    private void Start() {
        Init();
    }

    /*
    private void Move() {
        if (CanMove()) {
            GameCanvasControl.OnCanvasChangeEvent("Canvas Move");
        }
        else {
            GameMessageView.OnGameWarningMessageViewEvent(this.warningMessageTitle, this.warningMessageContent.ToString());
        }
    }
    */
    
    /*
    private void Search() {
        if (CanSearch()) {            
            PlayerBehaviourSearch.OnSearchEvent();
        }
        else {
            GameMessageView.OnGameWarningMessageViewEvent(this.warningMessageTitle, this.warningMessageContent.ToString());
        }
    }
    */

    /*
    private bool CanSearch() {
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
    */

    /*
    private void Fire() {
        if (CanFire()) {
            PlayerBehaviourFire.OnMakingFireEvent();
        }
        else {
            GameMessageView.OnGameWarningMessageViewEvent(this.warningMessageTitle, this.warningMessageContent.ToString());
        }
    }
    */

    /*
    private bool CanFire() {
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
    */
    
    private void RainGutter() {
        GameCanvasControl.OnCanvasChangeEvent("Canvas Rain Gutter");
        GameCanvasControl.OnCanvasOnEvent("Canvas Information");
    }

    public void Behaviour() {
        throw new System.NotImplementedException();
    }

    public bool CanBehaviour() {
        throw new System.NotImplementedException();
    }
}