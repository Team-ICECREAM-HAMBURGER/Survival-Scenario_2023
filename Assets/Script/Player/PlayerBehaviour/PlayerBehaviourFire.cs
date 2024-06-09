using System;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

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
    private string fireResultPanelTitleText;
    private StringBuilder fireResultPanelContentText;
    
    [Space(10f)] 
    
    [Header("Loading Panel")]
    [SerializeField] private GameObject fireLoadingPanel;
    [SerializeField] private TMP_Text fireLoadingTitle;
    

    [Space(10f)]
    
    [Header("Fire Term Indicator")]
    [SerializeField] private TMP_Text fireTermText;
    
    private float successPercent;
    private int fireTerm;
    private int fireTermRandomMin;
    private int fireTermRandomMax;
    private int spentTerm;
    
    
    public void Init() {
        this.successPercent = 55f;
        this.spentTerm = 0;
        this.fireTerm = World.Instance.FireTerm;
        this.fireTermRandomMin = 20;
        this.fireTermRandomMax = 70;

        this.fireResultPanelTitleText = String.Empty;
        this.fireResultPanelContentText = new();

        this.fireTermText.text = this.fireTerm + "텀 남음";
    }

    private bool CanBehaviour() {
        return (this.requireItems.All(item => Player.Instance.Inventory[item.Key] >= this.requireItems[item.Key]));
    }
    
    public void Behaviour() {
        var randomPercentPivot = Random.Range(0, 100f);
        var isSuccess = false;
        
        if (World.Instance.HasFire) {
            PanelUpdate();
            
            return;
        }
        
        if (CanBehaviour()) {
            isSuccess = (randomPercentPivot <= this.successPercent);
            this.fireTerm = Random.Range(fireTermRandomMin, fireTermRandomMax);
            this.spentTerm = (isSuccess) ? 3 : 6;

            Player.Instance.StatusUpdate(this.requireStatusStamina, this.requireStatusBodyHeat, this.requireStatusHydration, this.requireStatusCalories);
            Player.Instance.InventoryUpdate(this.requireItems);
        }
        
        World.Instance.HasFire = isSuccess;
        World.Instance.FireTimeUpdate(this.fireTerm);
        World.Instance.TimeUpdate(spentTerm);
        
        PanelUpdate(isSuccess);
    }

    private void PanelUpdate() {
        GameControlCanvas.OnCanvasUpdate.Invoke(this.fireCanvas, true);
        GameControlCanvas.OnCanvasUpdate.Invoke(this.outsideCanvas, false);
        GameControlCanvas.OnCanvasUpdate.Invoke(this.informationCanvas, false);
        GameControlCanvas.OnCanvasUpdate.Invoke(this.sideMenuCanvas, false);
    }
    
    private void PanelUpdate(bool isSuccess) {
        this.fireResultPanelTitleText = String.Empty;
        this.fireResultPanelContentText.Clear();
        
        this.fireTermText.text = this.fireTerm + "텀 남음";
        
        if (isSuccess) {
            this.fireResultPanelTitleText = "불이 붙었다!";

            this.fireResultPanelContentText.Append("- 결과\n");
            this.fireResultPanelContentText.Append("무사히 불을 피우는 데 성공했다.\n");
            this.fireResultPanelContentText.Append("이제 휴식처에서 따뜻한 밤을 지낼 수 있다.\n");

            this.fireResultPanelContentText.Append("\n");
            
            this.fireResultPanelContentText.Append("- 사용된 아이템\n");

            if (code == PanelCode.TOOL) {
                this.fireResultPanelContentText.Append(ItemManager.Instance.Items[GameControlType.Item.FIRE_TOOL].Name);
                this.fireResultPanelContentText.Append(" ");
                this.fireResultPanelContentText.Append(this.requiredFireToolAmount);
                this.fireResultPanelContentText.Append("개\n");
            }
            
            this.fireResultPanelContentText.Append(ItemManager.Instance.Items[GameControlType.Item.WOOD].Name);
            this.fireResultPanelContentText.Append(" ");
            this.fireResultPanelContentText.Append(this.requiredWoodAmount);
            this.fireResultPanelContentText.Append("개\n");
            this.fireResultPanelContentText.Append(ItemManager.Instance.Items[GameControlType.Item.TINDER].Name);
            this.fireResultPanelContentText.Append(" ");
            this.fireResultPanelContentText.Append(this.requiredTinderAmount);
            this.fireResultPanelContentText.Append("개\n");
            
            GameControlCanvas.OnCanvasUpdate.Invoke(this.fireCanvas, true);
            GameControlCanvas.OnCanvasUpdate.Invoke(this.outsideCanvas, false);
            GameControlCanvas.OnCanvasUpdate.Invoke(this.informationCanvas, false);
            GameControlCanvas.OnCanvasUpdate.Invoke(this.sideMenuCanvas, false);
        }
        else {
            switch (code) {
            case PanelCode.MATERIAL:
                title = "재료가 부족함.";
                content.Clear();
            
                content.Append("- 결과\n");
                content.Append("불을 피울 재료가 없다.\n");
                content.Append("최소한 나무 3개와 뗄감 1개, 돌 2개가 필요하다.\n");
            
                break;
            case PanelCode.TOOL:
                title = "실패했다.";
                content.Clear();
            
                content.Append("- 결과\n");
                content.Append("도구의 힘을 빌렸으나 역부족이었던 것 같다.\n");
                content.Append("그래도 다시 시도해볼 가치가 있어 보인다.\n");

                content.Append("\n");

                content.Append("- 사용된 아이템\n");
                content.Append(ItemManager.Instance.Items[GameControlType.Item.FIRE_TOOL].Name);
                content.Append(" ");
                content.Append(this.requiredFireToolAmount);
                content.Append("개\n");
                content.Append(ItemManager.Instance.Items[GameControlType.Item.WOOD].Name);
                content.Append(" ");
                content.Append(this.requiredWoodAmount);
                content.Append("개\n");
                content.Append(ItemManager.Instance.Items[GameControlType.Item.TINDER].Name);
                content.Append(" ");
                content.Append(this.requiredTinderAmount);
                content.Append("개\n");
            
                break;
            case PanelCode.HAND:
                title = "실패했다.";
                content.Clear();
            
                content.Append("- 결과\n");
                content.Append("온 우주의 힘을 빌려 맨 손으로 발악을 해보았지만 소용 없었다.\n");
                content.Append("아무래도 도구의 힘이 필요해보인다.\n");

                content.Append("\n");

                content.Append("- 사용된 아이템\n");
                content.Append(ItemManager.Instance.Items[GameControlType.Item.WOOD].Name);
                content.Append(" ");
                content.Append(this.requiredWoodAmount);
                content.Append("개\n");
                content.Append(ItemManager.Instance.Items[GameControlType.Item.TINDER].Name);
                content.Append(" ");
                content.Append(this.requiredTinderAmount);
                content.Append("개\n");
                
                break;
            }
        }
        
        this.fireLoadingTitle.text = "불을 피우는 중...";
        this.fireResultTitle.text = title;
        this.fireResultContent.text = content.ToString();
        
        this.fireLoadingPanel.SetActive(code != PanelCode.MATERIAL);
        this.fireResultPanel.SetActive(true);
    }
}
