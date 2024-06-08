using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public enum PanelCode {
    TOOL,   // 0
    HAND,   // 1
    MATERIAL,  // 2
    FAIL_HAND,      // 3
    FAIL_TOOL,      // 4
    PASS            // 5
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
    
    [SerializeField] private int minFireTerm;
    [SerializeField] private int maxFireTerm;

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
    
    private Dictionary<IItem, int> requiredItems;
    private float defaultPercent;
    private int requiredWoodAmount;
    private int requiredTinderAmount;
    private int requiredFireToolAmount;
    private int requiredStoneAmount;
    private int fireTerm;
    
    
    public void Init() {
        this.defaultPercent = 35f;
        this.requiredFireToolAmount = 1;
        this.requiredWoodAmount = 3;
        this.requiredTinderAmount = 1;
        this.requiredStoneAmount = 2;
        this.fireTerm = World.Instance.FireTerm;
        this.fireTermText.text = this.fireTerm + "텀 남음";
        
        this.requiredItems = new() {
            { ItemManager.Instance.Items[GameControlType.Item.WOOD], -this.requiredWoodAmount },
            { ItemManager.Instance.Items[GameControlType.Item.TINDER], -this.requiredTinderAmount },
            { ItemManager.Instance.Items[GameControlType.Item.STONE], -this.requiredStoneAmount }
        };
    }

    private bool CanBehaviour() {
        return (
            Player.Instance.Inventory[GameControlType.Item.STONE] >= this.requiredStoneAmount &&
            Player.Instance.Inventory[GameControlType.Item.WOOD] >= this.requiredWoodAmount &&
            Player.Instance.Inventory[GameControlType.Item.TINDER] >= this.requiredTinderAmount);
    }

    private bool CanPercentUp() {
        return (Player.Instance.Inventory[GameControlType.Item.FIRE_TOOL] >= this.requiredFireToolAmount);
    }

    public void Behaviour() {
        var spentTerm = 0;
        this.fireTerm = World.Instance.FireTerm;
        
        if (World.Instance.HasFire) {
            PanelUpdate(PanelCode.PASS, true);
            
            return;
        }
        
        if (CanBehaviour()) {
            var randomPercent = Random.Range(0, 100f);
            var isSuccess = false;
            var code = PanelCode.PASS;
            
            this.fireTerm = Random.Range(minFireTerm, maxFireTerm);
            
            if (CanPercentUp()) {    // 성공 확률 UP
                isSuccess = (randomPercent <= this.defaultPercent + 
                    ItemManager.Instance.Items[GameControlType.Item.FIRE_TOOL].RandomPercent);
                Player.Instance.StatusUpdate(
                    this.requireStatusStamina, 
                    this.requireStatusBodyHeat, 
                    this.requireStatusHydration, 
                    this.requireStatusCalories);
                Player.Instance.InventoryUpdate(GameControlType.Item.FIRE_TOOL, -this.requiredFireToolAmount);
                Player.Instance.InventoryUpdate(this.requiredItems);

                code = PanelCode.TOOL;
                spentTerm = 3;
            }
            else {  // 성공 확률 DEFAULT
                isSuccess = (randomPercent <= this.defaultPercent);
                Player.Instance.StatusUpdate(
                    this.requireStatusStamina * 1.25f, 
                    this.requireStatusBodyHeat * 1.25f, 
                    this.requireStatusHydration * 1.25f, 
                    this.requireStatusCalories * 1.25f);
                Player.Instance.InventoryUpdate(this.requiredItems);
                
                code = PanelCode.HAND;
                spentTerm = 6;
            }

            if (isSuccess) {
                World.Instance.HasFire = true;
                World.Instance.FireTimeUpdate(this.fireTerm + spentTerm);
            }
            
            PanelUpdate(code, isSuccess);
        }
        else {  // 재료 없음
            World.Instance.HasFire = false;
            PanelUpdate(PanelCode.MATERIAL, false);
        }
        
        World.Instance.TimeUpdate(spentTerm);
    }

    private void PanelUpdate(PanelCode code, bool isSuccess) {
        var title = String.Empty;
        var content = new StringBuilder();

        Debug.Log(code + " " + isSuccess);
        
        this.fireTermText.text = this.fireTerm + "텀 남음";
        
        if (code == PanelCode.PASS) {
            GameControlCanvas.OnCanvasUpdate.Invoke(this.fireCanvas, true);
            GameControlCanvas.OnCanvasUpdate.Invoke(this.outsideCanvas, false);
            GameControlCanvas.OnCanvasUpdate.Invoke(this.informationCanvas, false);
            GameControlCanvas.OnCanvasUpdate.Invoke(this.sideMenuCanvas, false);
            
            return;
        }
        
        if (isSuccess) {
            title = "불이 붙었다!";
            content.Clear();

            content.Append("- 결과\n");
            content.Append("무사히 불을 피우는 데 성공했다.\n");
            content.Append("이제 휴식처에서 따뜻한 밤을 지낼 수 있다.\n");

            content.Append("\n");
            
            content.Append("- 사용된 아이템\n");

            if (code == PanelCode.TOOL) {
                content.Append(ItemManager.Instance.Items[GameControlType.Item.FIRE_TOOL].Name);
                content.Append(" ");
                content.Append(this.requiredFireToolAmount);
                content.Append("개\n");
            }
            
            content.Append(ItemManager.Instance.Items[GameControlType.Item.WOOD].Name);
            content.Append(" ");
            content.Append(this.requiredWoodAmount);
            content.Append("개\n");
            content.Append(ItemManager.Instance.Items[GameControlType.Item.TINDER].Name);
            content.Append(" ");
            content.Append(this.requiredTinderAmount);
            content.Append("개\n");
            
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
