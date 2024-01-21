using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFire : MonoBehaviour {
    [SerializeField] private GameObject fireLoadingScreen;
    [SerializeField] private GameObject fireResultScreen;
    
    [Space(10f)]
    [SerializeField] private Button addWoodButton;
    [SerializeField] private Button cookingButton;
    [SerializeField] private Button returnToMenuButton;
    
    private StringBuilder resultStringBuilder;
    
    public delegate void MakingFireEventHandler();
    public static MakingFireEventHandler OnMakingFireEvent;
    
    
    private void Init() {
        this.fireLoadingScreen.SetActive(false);
        this.fireResultScreen.SetActive(true);
        
        this.resultStringBuilder = new StringBuilder();
        
        this.addWoodButton.onClick.AddListener(AddWood);
        this.cookingButton.onClick.AddListener(Cooking);
        this.returnToMenuButton.onClick.AddListener(ReturnToMenu);
        
        OnMakingFireEvent += MakingFire;
    }
    
    private void Start() {
        Init();
    }

    private void MakingFire() {
        GameCanvasControl.OnCanvasChangeEvent("Canvas Fire");
        
        if (GameInfo.Instance.IsFireInstalled) {    // 이미 불이 피워져 있음.
            GameCanvasControl.OnCanvasOnEvent("Canvas Information");
            
            return;
        }

        GameInfo.OnTimeUpdateEvent(1);
        this.resultStringBuilder.Clear();
        
        // 불 피우는 중 애니메이션
        this.fireLoadingScreen.SetActive(true);
        
        // 아이템 소모; 성공 여부와 상관없이 무조건 아이템은 소모함; 점화 도구 1개, 불쏘시개 2개, 나무 3개 이상.
        var fireTool = Player.Instance.Inventory[itemType.FIRE_TOOL]; 
        var kindling = Player.Instance.Inventory[itemType.KINDLING]; 
        var wood = Player.Instance.Inventory[itemType.WOOD];
        
        string itemResult = "- 소모된 아이템\n" +
                          $"{fireTool.ItemName} {fireTool.ItemUse(1):-#; 0}\n" +
                          $"{kindling.ItemName} {kindling.ItemUse(2):-#; 0}\n" +
                          $"{wood.ItemName} {wood.ItemUse(3):-#; 0}\n";
        
        // 스테이터스 소모; 성공 여부와 상관없이 무조건 스테이터스를 소모함; 체력 -20, 체온 -5, 수분 -10, 열량 -15
        float staminaValue = -20;
        float bodyHeatValue = -5;
        float hydrationValue = -10;
        float caloriesValue = -15;
        
        Player.Instance.StatusUpdate(staminaValue, bodyHeatValue, hydrationValue, caloriesValue);
        
        string statusResult = "- 스테이터스 소모량\n" +
                              $"체력 {staminaValue:+#; -#; 0}\n" +
                              $"체온 {bodyHeatValue:+#; -#; 0}\n" +
                              $"수분 {hydrationValue:+#; -#; 0}\n" +
                              $"열량 {caloriesValue:+#; -#; 0}\n";
        
        // 날씨에 따른 확률 결정
        if (GameInfo.Instance.CurrentWeather.WillCatchFire()) { // SUNNY = 40%; RAIN = 20%; SNOW = 20%;
            /*
             * 성공; 몇 텀?
             * 불 1회 300텀 ~ 400텀
             * 1일 500텀, 0.5일 250텀
             * 뗄감 1회 추가 -> 나무 1개 소모 -> 불 25텀 추가
             * 1일 수면 -> 뗄감 8회 ~ 4회
            */

            int value = Random.Range(300, 401);
            string fireResult = "- 결과\n" +
                            $"모닥불은 최대 {value}텀까지 유지된다.\n" +
                            $"불이 꺼지기 전에 {wood.ItemName}를 넣으면 텀이 연장된다.\n";

            this.resultStringBuilder.Append(fireResult);    // - 결과
            this.resultStringBuilder.Append("\n");
            this.resultStringBuilder.Append(itemResult);    // - 소모된 아이템
            this.resultStringBuilder.Append("\n");
            this.resultStringBuilder.Append(statusResult);  // - 스테이터스 소모량

            GameInfo.Instance.IsFireInstalled = true;
            
            // 결과 보고; 성공 시 OK 버튼 -> Fire 캔버스
            PlayerFireResultView.OnFireResultSuccess(this.resultStringBuilder.ToString());
            
            // 모닥불 텀 업데이트
            GameInfo.OnFireTimeUpdateEvent(value);
        }
        else {
            string fireResult = "- 결과\n" +
                                "노력했지만 끝내 모닥불을 피우지 못했다.\n" +
                                "아이템과 스테미나가 소모되었다.\n";

            this.resultStringBuilder.Append(fireResult);
            this.resultStringBuilder.Append("\n");
            this.resultStringBuilder.Append(itemResult);
            this.resultStringBuilder.Append("\n");
            this.resultStringBuilder.Append(statusResult);
            
            GameInfo.Instance.IsFireInstalled = false;
            
            // 결과 보고; 실패 시 OK 버튼 -> Outside 캔버스
            PlayerFireResultView.OnFireResultFail(this.resultStringBuilder.ToString());
        }
    }
    
    private void AddWood() {
        // TODO: Wood +5 -> Term +25
        GameInfo.OnFireTimeUpdateEvent(25);
    }

    private void Cooking() {
        // TODO: 
    }

    private void ReturnToMenu() {
        GameCanvasControl.OnCanvasChangeEvent("Canvas Outside");
        GameCanvasControl.OnCanvasOnEvent("Canvas Information");
    }
}
