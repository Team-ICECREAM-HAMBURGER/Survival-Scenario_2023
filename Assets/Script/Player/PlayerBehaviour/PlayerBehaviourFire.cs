using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerBehaviourFire : MonoBehaviour, IPlayerBehaviour {
    [SerializeField] private Canvas fireCanvas;
    [SerializeField] private Canvas outsideCanvas;
    
    [Space(10f)]
    
    [Header("Require Status")]
    [SerializeField] private float requireStatusStamina;
    [SerializeField] private float requireStatusBodyHeat;
    [SerializeField] private float requireStatusHydration;
    [SerializeField] private float requireStatusCalories;
    
    [Space(10f)] 
    
    [SerializeField] private GameObject fireResultPanel;
    [SerializeField] private TMP_Text fireResultTitle;
    [SerializeField] private TMP_Text fireResultContent;
    
    [Space(10f)] 
    
    [SerializeField] private GameObject fireLoadingPanel;
    [SerializeField] private TMP_Text fireLoadingTitle;

    private Dictionary<IItem, int> requiredItems;
    private float defaultPercent;
    private int requiredWoodAmount;
    private int requiredTinderAmount;
    private int requiredFireToolAmount;
    
    
    public void Init() {
        this.defaultPercent = 20f;
        this.requiredFireToolAmount = 1;
        this.requiredWoodAmount = 3;
        this.requiredTinderAmount = 2;
        
        this.requiredItems = new() {
            { ItemManager.Instance.Items[GameControlType.Item.WOOD], -this.requiredWoodAmount },
            { ItemManager.Instance.Items[GameControlType.Item.TINDER], -this.requiredTinderAmount }
        };
    }

    public void Behaviour() {
        if (Player.Instance.Inventory[GameControlType.Item.WOOD] >= this.requiredWoodAmount && 
            Player.Instance.Inventory[GameControlType.Item.TINDER] >= this.requiredTinderAmount) {
            var randomPercent = Random.Range(0, 100f);
            var isSuccess = false;
            
            if (Player.Instance.Inventory[GameControlType.Item.FIRE_TOOL] >= this.requiredFireToolAmount) {    // 성공 확률 UP
                isSuccess = (randomPercent <= this.defaultPercent + 
                    ItemManager.Instance.Items[GameControlType.Item.FIRE_TOOL].RandomPercent);
                Player.Instance.StatusUpdate(
                    this.requireStatusStamina, 
                    this.requireStatusBodyHeat, 
                    this.requireStatusHydration, 
                    this.requireStatusCalories);
                Player.Instance.InventoryUpdate(GameControlType.Item.FIRE_TOOL, -this.requiredFireToolAmount);
                Player.Instance.InventoryUpdate(this.requiredItems);
                
                PanelUpdate(1, isSuccess);
                World.Instance.WorldTimeUpdate(3);
            }
            else {  // 성공 확률 DEFAULT
                isSuccess = (randomPercent <= this.defaultPercent);
                Player.Instance.StatusUpdate(
                    this.requireStatusStamina * 1.25f, 
                    this.requireStatusBodyHeat * 1.25f, 
                    this.requireStatusHydration * 1.25f, 
                    this.requireStatusCalories * 1.25f);
                Player.Instance.InventoryUpdate(this.requiredItems);
                
                PanelUpdate(1, isSuccess);
                World.Instance.WorldTimeUpdate(6);
            }
        }
        else {  // 재료 없음
            PanelUpdate(0, false);
            World.Instance.WorldTimeUpdate(6);
        }
    }

    private void PanelUpdate(int code, bool isSuccess) {
        var title = String.Empty;
        var content = new StringBuilder();
        
        if (isSuccess) {
            title = "불이 붙었다.";
            content.Clear();

            content.Append("- 결과\n");
            content.Append("무사히 불을 피우는 데 성공했다.\n");
            content.Append("이제 휴식처에서 따뜻한 밤을 지낼 수 있다.\n");

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
            
            GameControlCanvas.OnCanvasUpdate.Invoke(this.fireCanvas, true);
            GameControlCanvas.OnCanvasUpdate.Invoke(this.outsideCanvas, false);
        }
        else {
            switch (code) {
                case 0:
                    title = "재료가 부족함.";
                    content.Clear();
            
                    content.Append("- 결과\n");
                    content.Append("불을 피울 재료가 없다.\n");
                    content.Append("최소한 나무 3개와 뗄감 2개가 필요하다.\n");
            
                    break;
                case 1:
                    title = "실패했다.";
                    content.Clear();
            
                    content.Append("- 결과\n");
                    content.Append("온 우주의 힘을 빌려 발악을 해보았지만 끝내 불이 붙지 않았다.\n");
                    content.Append("재료를 낭비했다.\n");

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
        
        this.fireLoadingPanel.SetActive(isSuccess);
        this.fireResultPanel.SetActive(true);
    }
}
