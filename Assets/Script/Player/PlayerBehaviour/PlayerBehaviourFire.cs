using System;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

enum FirePanelType {
    SUCCESS,
    FAILED,
    NO_MATERIAL,
    NO_WOODS,
    PASS
}

public class PlayerBehaviourFire : MonoBehaviour, IPlayerBehaviour {
    [SerializeField] private Canvas fireCanvas;
    [SerializeField] private Canvas outsideCanvas;
    [SerializeField] private Canvas informationCanvas;
    [SerializeField] private Canvas sideMenuCanvas;
    
    [Space(10f)]
    
    [Header("Require Status")]
    [SerializeField] private float requireStatusStamina;
    [SerializeField] private float requireStatusBodyHeat;
    [SerializeField] private float requireStatusHydration;
    [SerializeField] private float requireStatusCalories;

    [Space(10f)] 
    
    [Header("Require Items")] 
    [SerializeField] private GameControlDictionary.RequireItemsFire requireItems;
    
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
    private int spentTerm;
    private float successPercent;
    private string fireResultPanelTitleText;
    private StringBuilder fireResultPanelContentText;
    private FirePanelType fireResultPanelChangeType;

    
    public void Init() {
        this.successPercent = 55f;
        this.spentTerm = 0;
        this.fireTermRandomMin = 2;
        this.fireTermRandomMax = 10;
        this.fireTermAddWood = 3;

        this.fireResultPanelTitleText = String.Empty;
        this.fireResultPanelContentText = new();

        PanelUpdateFireTerm();
    }

    private bool CanBehaviour() {
        return (this.requireItems.All(item => 
            Player.Instance.Inventory[item.Key] >= Mathf.Abs(this.requireItems[item.Key])));
    }
    
    public void Behaviour() {
        if (World.Instance.HasFire) {   // 불이 이미 피워져 있음; 화면 전환
            this.fireResultPanelChangeType = FirePanelType.PASS;
            PanelUpdate(this.fireResultPanelChangeType);
            
            return;
        }
        
        if (CanBehaviour()) {   // 재료가 있음; 성공 or 실패
            var randomPercentPivot = Random.Range(0, 100f);
            var isSuccess = (randomPercentPivot <= this.successPercent);
            
            this.fireResultPanelChangeType = (isSuccess) ? FirePanelType.SUCCESS : FirePanelType.FAILED;
            this.spentTerm = 5;
            
            Player.Instance.StatusUpdate(
                this.requireStatusStamina, 
                this.requireStatusBodyHeat, 
                this.requireStatusHydration, 
                this.requireStatusCalories);
            Player.Instance.InventoryUpdate(this.requireItems);
            
            World.Instance.HasFire = isSuccess;
            World.Instance.FireTerm = (isSuccess) ? (Random.Range(this.fireTermRandomMin, this.fireTermRandomMax) + this.spentTerm) : 0;
            World.Instance.TimeUpdate(this.spentTerm);
            
            GameInformationManager.OnGameDataSaveEvent();
        }
        else {  // 재료가 없음; 실패
            this.fireResultPanelChangeType = FirePanelType.NO_MATERIAL;
            this.spentTerm = 0;
        }
        
        PanelUpdate(this.fireResultPanelChangeType);
    }

    public void BehaviourAddWoods(int value) {
        if (Player.Instance.Inventory[GameControlType.Item.WOOD] >= Mathf.Abs(value)) { // 나무 추가 가능
            Player.Instance.InventoryUpdate(GameControlType.Item.WOOD, value);
            World.Instance.FireTerm += this.fireTermAddWood;
            
            PanelUpdateFireTerm();
            GameInformationManager.OnGameDataSaveEvent();
        }
        else {  // 나무 추가 불가; 재료 부족
            PanelUpdate(FirePanelType.NO_WOODS);
        }
    }

    public void BehaviourCooking() {
        
    }
    
    private void PanelUpdate(FirePanelType type) {
        var isLoading = true;
        
        this.fireResultPanelTitleText = String.Empty;
        this.fireResultPanelContentText.Clear();

        PanelUpdateFireTerm();
        
        switch (type) {
            case FirePanelType.SUCCESS :    // 불 피우기 성공
                isLoading = true;

                this.fireResultPanelTitleText = "불이 붙었다!";

                this.fireResultPanelContentText.Append("- 결과\n");
                this.fireResultPanelContentText.Append("무사히 불을 피우는 데 성공했다.\n");
                this.fireResultPanelContentText.Append("이제 휴식처에서 따뜻한 밤을 지낼 수 있다.\n");
                
                this.fireResultPanelContentText.Append("\n");
        
                this.fireResultPanelContentText.Append("- 사용된 아이템\n");

                PanelUpdateCanvasSet();

                break;
            
            case FirePanelType.FAILED :     // 불 피우기 실패
                isLoading = true;
                
                this.fireResultPanelTitleText = "실패했다.";
            
                this.fireResultPanelContentText.Append("- 결과\n");
                this.fireResultPanelContentText.Append("온 우주의 힘을 빌려 발악을 해보았지만 소용 없었다.\n");
                this.fireResultPanelContentText.Append("그래도 다시 시도해볼 가치가 있어 보인다.\n");

                this.fireResultPanelContentText.Append("\n");
        
                this.fireResultPanelContentText.Append("- 사용된 아이템\n");

                break;
            
            case FirePanelType.NO_MATERIAL :    // 재료가 없음
                isLoading = false;
                
                this.fireResultPanelTitleText = "재료가 부족하다.";
            
                this.fireResultPanelContentText.Append("- 결과\n");
                this.fireResultPanelContentText.Append("불을 피우는 데 필요한 재료가 부족하다.\n");
                this.fireResultPanelContentText.Append("재료를 모아서 다시 시도해보자.\n");
                
                this.fireResultPanelContentText.Append("\n");
        
                this.fireResultPanelContentText.Append("- 필요한 아이템\n");

                break;
            
            case FirePanelType.NO_WOODS :
                isLoading = false;
                
                this.fireResultPanelTitleText = "나무가 없다.";

                this.fireResultPanelContentText.Append("- 결과\n");
                this.fireResultPanelContentText.Append("불을 연장할만큼의 나무가 없다.\n");

                this.fireResultPanelContentText.Append("\n");
                
                this.fireResultPanelContentText.Append("- 필요한 아이템\n");
                this.fireResultPanelContentText.Append("나무 5개\n");
                
                this.fireResultTitle.text = this.fireResultPanelTitleText;
                this.fireResultContent.text = this.fireResultPanelContentText.ToString();
                this.fireResultPanel.SetActive(true);
                
                return;
            
            case FirePanelType.PASS :
                isLoading = false;
                PanelUpdateCanvasSet();

                return;
        }
        
        foreach (var VARIABLE in this.requireItems) {
            this.fireResultPanelContentText.Append(ItemManager.Instance.Items[VARIABLE.Key].Name);
            this.fireResultPanelContentText.Append(" ");
            this.fireResultPanelContentText.Append(Mathf.Abs(VARIABLE.Value));
            this.fireResultPanelContentText.Append("개\n");
        }
        
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
