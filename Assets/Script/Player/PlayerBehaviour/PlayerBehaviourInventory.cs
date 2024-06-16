using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerBehaviourInventory : MonoBehaviour, IPlayerBehaviour {
    [Header("Item Information Panel")]
    [SerializeField] private TMP_Text itemInfoTitle;
    [SerializeField] private TMP_Text itemInfoContent;

    [Space(25f)]
    
    [Header("Inventory Indicator")]
    [SerializeField] private Slider inventoryAmountIndicator;
    [SerializeField] private TMP_Text inventoryAmountValueText;

    private int inventoryCurrentValue;
    private int inventoryMaxValue;
    
    public static UnityEvent<string, string> OnItemInfoUpdate;
    public static UnityEvent OnItemUpdate;


    public void Init() {
        this.inventoryMaxValue = 25;
        this.inventoryCurrentValue = Player.Instance.Inventory.Sum(x => x.Value);
        
        OnItemInfoUpdate = new();
        OnItemInfoUpdate.AddListener(PanelUpdate);

        OnItemUpdate = new();
        OnItemUpdate.AddListener(Behaviour);
    }

    public void Behaviour() {
        this.itemInfoTitle.text = "인벤토리";
        this.itemInfoContent.text = "아이템 항목을 선택하면 세부 사항을 볼 수 있습니다.";
        
        foreach (var VARIABLE in Player.Instance.Inventory) {
            ItemManager.Instance.Items[VARIABLE.Key].InventoryCountUpdate(VARIABLE.Value > 0 ? VARIABLE.Value : 0);
        }

        this.inventoryCurrentValue = Player.Instance.Inventory.Sum(x => x.Value);
        this.inventoryAmountIndicator.maxValue = this.inventoryMaxValue;
        this.inventoryAmountIndicator.value = this.inventoryCurrentValue;
        this.inventoryAmountValueText.text = this.inventoryCurrentValue + " / " + this.inventoryMaxValue;
        
        GameInformationManager.OnGameDataSaveEvent();
    }

    private void PanelUpdate(string title, string content) {
        this.itemInfoTitle.text = title;
        this.itemInfoContent.text = content;
    }
}
