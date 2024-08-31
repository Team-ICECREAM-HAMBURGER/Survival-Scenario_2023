using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerBehaviourInventory : PlayerBehaviour {
    [Space(25f)]
    
    [Header("Game Screen Update Resource")] 
    [SerializeField] private Canvas inventoryCanvas;
    [SerializeField] private Canvas shelterCanvas;
    [SerializeField] private Canvas informationMonitorCanvas;
    [SerializeField] private Canvas sideMenuCanvas;
    
    [Space(25f)]
    
    [Header("Item Information Panel")]
    [SerializeField] private TMP_Text itemInfoTitle;
    [SerializeField] private TMP_Text itemInfoContent;
    
    [Space(25f)]
    
    [Header("Inventory Space Indicator")]
    [SerializeField] private TMP_Text inventorySpaceText;
    [SerializeField] private Slider inventorySpaceIndicator;

    private int inventorySpaceValue;
    private int inventorySpaceMaxValue;
    
    public static UnityEvent<(string, string)> OnItemInfoPanelUpdate;
    public static UnityEvent OnInventoryInfoPanelUpdate;
    public static UnityEvent OnItemUse;


    public override void Init() {
        this.itemInfoTitle.text = "인벤토리";
        this.itemInfoContent.text = "아이템 항목을 선택하면 세부 사항을 볼 수 있습니다.";
        this.inventorySpaceMaxValue = 25;
        this.inventorySpaceValue = PlayerBehaviourManager.Instance.GetInventoryAmountTotal();
        
        OnItemInfoPanelUpdate = new();
        OnItemInfoPanelUpdate.AddListener(PanelUpdateItemInfo);

        OnInventoryInfoPanelUpdate = new();
        OnInventoryInfoPanelUpdate.AddListener(PanelUpdateInventoryInfo);

        OnItemUse = new();
        OnItemUse.AddListener(Behaviour);
    }

    public override void Behaviour() {
        // Player Inventory Invoke
        PlayerBehaviourManager.Instance.InventorySync();

        // Inventory Info Panel Update
        PanelUpdateInventoryInfo();
        
        // Game Data Update
        PlayerBehaviourManager.Instance.GameDataSaveInvoke();
    }
    
    private void PanelUpdateInventoryInfo() {
        this.inventorySpaceValue = PlayerBehaviourManager.Instance.GetInventoryAmountTotal();
        this.inventorySpaceIndicator.maxValue = this.inventorySpaceMaxValue;
        this.inventorySpaceIndicator.value = this.inventorySpaceValue;
        this.inventorySpaceText.text = this.inventorySpaceValue + " / " + this.inventorySpaceMaxValue;
    }

    private void PanelUpdateItemInfo((string, string) value) {
        this.itemInfoTitle.text = value.Item1;
        this.itemInfoContent.text = value.Item2;
    }
    
    public void PanelUpdateCanvasSetEnter() {
        this.shelterCanvas.enabled = false;
        this.inventoryCanvas.enabled = true;
        this.sideMenuCanvas.enabled = false;
        this.informationMonitorCanvas.enabled = false;
    }

    public void PanelUpdateCanvasSetReturn() {
        this.shelterCanvas.enabled = true;
        this.inventoryCanvas.enabled = false;
        this.sideMenuCanvas.enabled = true;
        this.informationMonitorCanvas.enabled = true;
    }
}
