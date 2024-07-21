using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

enum FirePanelType {
    SUCCESS,
    FAIL,
    NO_MATERIAL,
    NO_WOODS,
    PASS
}

public class PlayerBehaviourFire : PlayerBehaviour {
    [Space(25f)] 
    
    [Header("Behaviour Require Item")]
    [SerializeField] private UnityEvent OnPlayerInventoryUpdateMakeFire;
    [SerializeField] private UnityEvent OnPlayerInventoryUpdateAddWood;
    
    [Space(25f)]
    
    [Header("Game Screen Update Resource")]
    [SerializeField] private Canvas fireCanvas;
    [SerializeField] private Canvas outsideCanvas;
    [SerializeField] private Canvas informationCanvas;
    [SerializeField] private Canvas sideMenuCanvas;
    
    [Space(25f)]
    
    [Header("Behaviour Result Panel")]
    [SerializeField] private GameObject fireResultPanel;
    [SerializeField] private TMP_Text fireResultTitle;
    [SerializeField] private TMP_Text fireResultContent;
    
    [Space(25f)]
    
    [Header("Behaviour Loading Panel")]
    [SerializeField] private GameObject fireLoadingPanel;
    [SerializeField] private TMP_Text fireLoadingTitle;
    
    [Space(25f)]
    
    [Header("Fire Term Indicator")]
    [SerializeField] private TMP_Text fireTermText;
    
    private static int ADD_WOOD = 1;
    private static int FIRE_WOOD = 2;
    private static int FIRE_TINDER = 1;
    private static int FIRE_TOOL = 1;

    private readonly List<(GameControlType.Item, int)> canFireList = new() {
        (GameControlType.Item.WOOD, FIRE_WOOD),
        (GameControlType.Item.TINDER, FIRE_TINDER),
        (GameControlType.Item.FIRE_TOOL, FIRE_TOOL)
    };
    
    private int fireTermAddWood;
    private int fireTermRandomMin;
    private int fireTermRandomMax;
    private int spendTime;
    private float successPercent;
    private string fireResultTitleText;
    private StringBuilder fireResultContentText;
    private FirePanelType fireResultPanelChangeType;

    
    public override void Init() {
        this.successPercent = 50f;
        this.spendTime = 0;
        this.fireTermRandomMin = 2;
        this.fireTermRandomMax = 10;
        this.fireTermAddWood = 3;

        this.fireResultTitleText = String.Empty;
        this.fireResultContentText = new();

        this.OnPlayerStatusUpdate = new();
        
        PanelUpdateFireTerm();
    }
    
    private bool CanBehaviour(List<(GameControlType.Item, int)> values) {
        return PlayerBehaviourManager.Instance.CanBehaviour(values);
    }

    private bool CanBehaviour((GameControlType.Item, int) value) {
        return PlayerBehaviourManager.Instance.CanBehaviour(value);
    }
    
    private bool CanBehaviour() {
        return World.Instance.HasFire;
    }
    
    public override void Behaviour() {
        if (CanBehaviour()) {   // Already Have Fire; Change Panel
            this.fireResultPanelChangeType = FirePanelType.PASS;
            
            PanelUpdate(this.fireResultPanelChangeType);
            
            return;
        }
        
        if (CanBehaviour(this.canFireList)) {   // Can Make fire; Success or Fail
            var isSuccess = GameRandomEventManager.Instance.RandomEventPercentSelect(this.successPercent);
            
            this.fireResultPanelChangeType = (isSuccess) ? 
                FirePanelType.SUCCESS : FirePanelType.FAIL;
            this.spendTime = 5;
            
            // Player Status Update
            this.OnPlayerStatusUpdate.Invoke();
            
            // Player Status Effect Invoke
            PlayerStatusEffectManager.Instance.StatusEffectInvoke();
            
            // Player Inventory Update
            this.OnPlayerInventoryUpdateMakeFire.Invoke();
            
            // Word Info. Update
            World.Instance.HasFire = isSuccess;
            World.Instance.FireTerm = (isSuccess) ? 
                (Random.Range(this.fireTermRandomMin, this.fireTermRandomMax) + this.spendTime) : 0;
            World.Instance.TimeUpdate(this.spendTime);
            
            // Game Data Update
            GameInformationManager.OnGameDataSaveEvent();
        }
        else {  // Not Enough Materials
            this.fireResultPanelChangeType = FirePanelType.NO_MATERIAL;
            this.spendTime = 0;
        }
        
        PanelUpdate(this.fireResultPanelChangeType);
    }

    public void BehaviourAddWoods() {
        if (CanBehaviour((GameControlType.Item.WOOD, ADD_WOOD))) { // Can Add Woods
            // Player Inventory Update
            this.OnPlayerInventoryUpdateAddWood.Invoke();
            
            // World Info. Update
            World.Instance.FireTerm += this.fireTermAddWood;

            // Game Data Update
            GameInformationManager.OnGameDataSaveEvent();
            
            PanelUpdateFireTerm();
        }
        else {  // Not Enough Woods;
            PanelUpdate(FirePanelType.NO_WOODS);
        }
    }

    public void BehaviourCooking() {
    }
    
    private void PanelUpdate(FirePanelType type) {
        var needLoading = true;
        
        this.fireResultTitleText = String.Empty;
        this.fireResultContentText.Clear();

        PanelUpdateFireTerm();
        
        switch (type) {
            case FirePanelType.SUCCESS :    // Success!
                needLoading = true;

                this.fireResultTitleText = "불이 붙었다!";

                this.fireResultContentText.Append("- 결과\n");
                this.fireResultContentText.Append("무사히 불을 피우는 데 성공했다.\n");
                this.fireResultContentText.Append("이제 휴식처에서 따뜻한 밤을 지낼 수 있다.\n");
                
                this.fireResultContentText.Append("\n");
        
                this.fireResultContentText.Append("- 사용된 아이템\n");

                PanelUpdateCanvasSet();

                break;
            
            case FirePanelType.FAIL :     // Fail!
                needLoading = true;
                
                this.fireResultTitleText = "실패했다.";
            
                this.fireResultContentText.Append("- 결과\n");
                this.fireResultContentText.Append("온 우주의 힘을 빌려 발악을 해보았지만 소용 없었다.\n");
                this.fireResultContentText.Append("그래도 다시 시도해볼 가치가 있어 보인다.\n");

                this.fireResultContentText.Append("\n");
        
                this.fireResultContentText.Append("- 사용된 아이템\n");

                break;
            
            case FirePanelType.NO_MATERIAL :    // Not Enough Materials
                needLoading = false;
                
                this.fireResultTitleText = "재료가 부족하다.";
            
                this.fireResultContentText.Append("- 결과\n");
                this.fireResultContentText.Append("불을 피우는 데 필요한 재료가 부족하다.\n");
                this.fireResultContentText.Append("재료를 모아서 다시 시도해보자.\n");
                
                this.fireResultContentText.Append("\n");
        
                this.fireResultContentText.Append("- 필요한 아이템\n");

                break;
            
            case FirePanelType.NO_WOODS :   // Not Enough Woods
                needLoading = false;
                
                this.fireResultTitleText = "나무가 없다.";

                this.fireResultContentText.Append("- 결과\n");
                this.fireResultContentText.Append("불을 연장할만큼의 나무가 없다.\n");

                this.fireResultContentText.Append("\n");
                
                this.fireResultContentText.Append("- 필요한 아이템\n");

                // Require Items for Add Wood;
                this.fireResultContentText.Append("나무 ");
                this.fireResultContentText.Append(ADD_WOOD);
                this.fireResultContentText.Append("개\n");
                
                this.fireResultTitle.text = this.fireResultTitleText;
                this.fireResultContent.text = this.fireResultContentText.ToString();
                this.fireResultPanel.SetActive(true);
                
                return;
            
            case FirePanelType.PASS :   // Already Have fire;
                needLoading = false;
                
                PanelUpdateCanvasSet();

                return;
        }

        // Require Items for Make Fire;
        this.fireResultContentText.Append("나무 ");
        this.fireResultContentText.Append(FIRE_WOOD);
        this.fireResultContentText.Append("개\n");
        
        this.fireResultContentText.Append("불쏘시개 ");
        this.fireResultContentText.Append(FIRE_TINDER);
        this.fireResultContentText.Append("개\n");
        
        this.fireResultContentText.Append("점화도구 ");
        this.fireResultContentText.Append(FIRE_TOOL);
        this.fireResultContentText.Append("개\n");
        
        // Loading Panel Update
        this.fireLoadingTitle.text = "불을 피우는 중...";
        this.fireResultTitle.text = this.fireResultTitleText;
        this.fireResultContent.text = this.fireResultContentText.ToString();
        
        this.fireLoadingPanel.SetActive(needLoading);
        this.fireResultPanel.SetActive(true);
    }
    
    private void PanelUpdateCanvasSet() {
        GameControlCanvas.OnCanvasUpdate.Invoke(this.fireCanvas, true);
        GameControlCanvas.OnCanvasUpdate.Invoke(this.outsideCanvas, false);
        GameControlCanvas.OnCanvasUpdate.Invoke(this.informationCanvas, false);
        GameControlCanvas.OnCanvasUpdate.Invoke(this.sideMenuCanvas, false);
    }

    private void PanelUpdateFireTerm() {
        this.fireTermText.text = World.Instance.FireTerm + "텀 남음";
    }
}
