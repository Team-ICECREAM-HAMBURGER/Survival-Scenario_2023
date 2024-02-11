using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviourMove : MonoBehaviour, IPlayerBehaviour {
    [Header("Loading Screen")]
    [SerializeField] private GameObject moveLoadingScreen;
    
    [Space(10f)]
    
    // TODO: [Header("Behaviour Result")]
    
    [Header("UI Buttons")]
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;
    
    private float requireStatusValue;
    
    
    private void Init() {
        this.moveLoadingScreen.SetActive(false);
        
        this.yesButton.onClick.AddListener(Behaviour);
        this.noButton.onClick.AddListener(ReturnToMain);
        
        this.requireStatusValue = 50f;
    }

    private void Start() {
        Init();
    }

    public bool CanBehaviour() {
        //this.warningMessageContent.Clear();
        
        if (Player.Instance.StatusEffectCheck(StatusEffectType.INJURED)) {
            //this.warningMessageTitle = "부상을 입음";
            //this.warningMessageContent.Append("부상을 입은 상태에서는 다른 지역으로 이동할 수 없다.\n");
            //this.warningMessageContent.Append("부상을 회복하기 위해서는 휴식과 잠이 중요하다.\n");
            //this.warningMessageContent.Append("만약 의료품이 있다면 더욱 빠르게 회복이 가능하다.\n");
            
            return false;
        }
        
        if (!Player.Instance.StatusCheck(this.requireStatusValue)) {
            //this.warningMessageTitle = "스테이터스가 너무 낮음";
            //this.warningMessageContent.Append("다른 지역으로 이동할 수 있을만큼 스테이터스가 충분하지 않다.\n");
            //this.warningMessageContent.Append("스테이터스는 음식, 물, 휴식 등으로 회복할 수 있다.\n");
            //this.warningMessageContent.Append("\n");
            //this.warningMessageContent.Append("- 스테이터스 요구 사항\n");
            //this.warningMessageContent.Append($"체력: {status}% 이상\n");
            //this.warningMessageContent.Append($"체온: {status}% 이상\n");
            //this.warningMessageContent.Append($"수분: {status}% 이상\n");
            //this.warningMessageContent.Append($"허기: {status}% 이상\n");
            return false;
        }

        return true;
    }
    
    public void Behaviour() {
        this.moveLoadingScreen.SetActive(true);
        Player.Instance.StatusDecrease(25f);
        // TODO : this.moveResultScreen -> Text(Title, Content) Update
    }

    private void ReturnToMain() {
        GameCanvasControl.OnCanvasChangeEvent("Canvas Outside");
        GameCanvasControl.OnCanvasOnEvent("Canvas Information");
    }
}