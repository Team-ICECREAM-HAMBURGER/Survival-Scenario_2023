using System;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

enum FirePanelType {
    SUCCESS,
    FAIL,
    NO_MATERIAL,
    NO_WOODS,
    PASS
}

public class PlayerBehaviourFire : PlayerBehaviour {
    [SerializeField] private Canvas fireCanvas;
    [SerializeField] private Canvas outsideCanvas;
    [SerializeField] private Canvas informationCanvas;
    [SerializeField] private Canvas sideMenuCanvas;
    
    [Space(10f)]
    
    [Header("Require Status")]
    [field: SerializeField] private GameControlDictionary.RequireStatus requireStatuses;
    
    [Space(10f)] 
    
    [Header("Require Items")] 
    [SerializeField] private GameControlDictionary.RequireItem requireItemsFire;
    [SerializeField] private GameControlDictionary.RequireItem requireItemsAddWood;
    
    [Space(10f)]
    
    [Header("Result Panel")]
    [SerializeField] private GameObject fireResultPanel;
    [SerializeField] private TMP_Text fireResultTitle;
    [SerializeField] private TMP_Text fireResultContent;
    
    [Space(10f)] 
    
    [Header("Loading Panel")]
    [SerializeField] private GameObject fireLoadingPanel;
    [SerializeField] private TMP_Text fireLoadingTitle;
    
    [Space(10f)]
    
    [Header("Fire Term Indicator")]
    [SerializeField] private TMP_Text fireTermText;
    
    private int fireTermAddWood;
    private int fireTermRandomMin;
    private int fireTermRandomMax;
    private int spendTime;
    private float successPercent;
    private string fireResultPanelTitleText;
    private StringBuilder fireResultPanelContentText;
    private FirePanelType fireResultPanelChangeType;

    
    public override void Init() {
        this.successPercent = 50f;
        this.spendTime = 0;
        this.fireTermRandomMin = 2;
        this.fireTermRandomMax = 10;
        this.fireTermAddWood = 3;

        this.fireResultPanelTitleText = String.Empty;
        this.fireResultPanelContentText = new();

        PanelUpdateFireTerm();
    }
    
    private bool CanBehaviour(GameControlDictionary.RequireItem requireItem) {
        return (requireItem.All(item => 
                Player.Instance.Inventory[item.Key] >= Mathf.Abs(requireItem[item.Key]))
            );
    }
    
    public override void Behaviour() {
        if (World.Instance.HasFire) {   // Already Have Fire; Change Panel
            this.fireResultPanelChangeType = FirePanelType.PASS;
            
            PanelUpdate(this.fireResultPanelChangeType);
            
            return;
        }
        
        if (CanBehaviour(this.requireItemsFire)) {   // Can Make fire; Success or Fail
            var isSuccess = GameRandomEventManager.Instance.RandomEventPercentSelect(this.successPercent);
            
            this.fireResultPanelChangeType = 
                (isSuccess) ? FirePanelType.SUCCESS : FirePanelType.FAIL;
            this.spendTime = 5;
            
            // Player Status Update
            foreach (var VARIABLE in this.requireStatuses) {
                PlayerStatusManager.Instance.Statuses[VARIABLE.Key].StatusUpdate(-VARIABLE.Value);
            }
            
            // Player Status Effect Invoke
            PlayerStatusEffectManager.Instance.StatusEffectInvoke();
            
            // Player Inventory Update
            foreach (var VARIABLE in this.requireItemsFire) {
                ItemManager.Instance.ItemMaterials[VARIABLE.Key].ItemUse(VARIABLE.Value);
            }
            
            // Word Info. Update
            World.Instance.HasFire = isSuccess;
            World.Instance.FireTerm = 
                (isSuccess) ? (Random.Range(this.fireTermRandomMin, this.fireTermRandomMax) + this.spendTime) : 0;
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
        if (CanBehaviour(this.requireItemsAddWood)) { // Can Add Woods
            // Player Inventory Update
            foreach (var VARIABLE in this.requireItemsAddWood) {
                ItemManager.Instance.ItemMaterials[VARIABLE.Key].ItemUse(VARIABLE.Value);
            }
            
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
        // TODO
    }
    
    private void PanelUpdate(FirePanelType type) {
        var isLoading = true;
        
        this.fireResultPanelTitleText = String.Empty;
        this.fireResultPanelContentText.Clear();

        PanelUpdateFireTerm();
        
        switch (type) {
            case FirePanelType.SUCCESS :    // Success!
                isLoading = true;

                this.fireResultPanelTitleText = "불이 붙었다!";

                this.fireResultPanelContentText.Append("- 결과\n");
                this.fireResultPanelContentText.Append("무사히 불을 피우는 데 성공했다.\n");
                this.fireResultPanelContentText.Append("이제 휴식처에서 따뜻한 밤을 지낼 수 있다.\n");
                
                this.fireResultPanelContentText.Append("\n");
        
                this.fireResultPanelContentText.Append("- 사용된 아이템\n");

                PanelUpdateCanvasSet();

                break;
            
            case FirePanelType.FAIL :     // Fail!
                isLoading = true;
                
                this.fireResultPanelTitleText = "실패했다.";
            
                this.fireResultPanelContentText.Append("- 결과\n");
                this.fireResultPanelContentText.Append("온 우주의 힘을 빌려 발악을 해보았지만 소용 없었다.\n");
                this.fireResultPanelContentText.Append("그래도 다시 시도해볼 가치가 있어 보인다.\n");

                this.fireResultPanelContentText.Append("\n");
        
                this.fireResultPanelContentText.Append("- 사용된 아이템\n");

                break;
            
            case FirePanelType.NO_MATERIAL :    // Not Enough Materials
                isLoading = false;
                
                this.fireResultPanelTitleText = "재료가 부족하다.";
            
                this.fireResultPanelContentText.Append("- 결과\n");
                this.fireResultPanelContentText.Append("불을 피우는 데 필요한 재료가 부족하다.\n");
                this.fireResultPanelContentText.Append("재료를 모아서 다시 시도해보자.\n");
                
                this.fireResultPanelContentText.Append("\n");
        
                this.fireResultPanelContentText.Append("- 필요한 아이템\n");

                break;
            
            case FirePanelType.NO_WOODS :   // Not Enough Woods
                isLoading = false;
                
                this.fireResultPanelTitleText = "나무가 없다.";

                this.fireResultPanelContentText.Append("- 결과\n");
                this.fireResultPanelContentText.Append("불을 연장할만큼의 나무가 없다.\n");

                this.fireResultPanelContentText.Append("\n");
                
                this.fireResultPanelContentText.Append("- 필요한 아이템\n");

                foreach (var VARIABLE in this.requireItemsAddWood) {
                    this.fireResultPanelContentText.Append(ItemManager.Instance.Items[VARIABLE.Key].Name);
                    this.fireResultPanelContentText.Append(" ");
                    this.fireResultPanelContentText.Append(Mathf.Abs(VARIABLE.Value));
                    this.fireResultPanelContentText.Append("개\n");
                }
                
                this.fireResultTitle.text = this.fireResultPanelTitleText;
                this.fireResultContent.text = this.fireResultPanelContentText.ToString();
                this.fireResultPanel.SetActive(true);
                
                return;
            
            case FirePanelType.PASS :   // Already Have fire;
                isLoading = false;
                
                PanelUpdateCanvasSet();

                return;
        }
        
        // Require Items for Make Fire;
        foreach (var VARIABLE in this.requireItemsFire) {   
            this.fireResultPanelContentText.Append(ItemManager.Instance.Items[VARIABLE.Key].Name);
            this.fireResultPanelContentText.Append(" ");
            this.fireResultPanelContentText.Append(Mathf.Abs(VARIABLE.Value));
            this.fireResultPanelContentText.Append("개\n");
        }
        
        // Loading Panel Update
        this.fireLoadingTitle.text = "불을 피우는 중...";
        this.fireResultTitle.text = this.fireResultPanelTitleText;
        this.fireResultContent.text = this.fireResultPanelContentText.ToString();
        
        this.fireLoadingPanel.SetActive(isLoading);
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
