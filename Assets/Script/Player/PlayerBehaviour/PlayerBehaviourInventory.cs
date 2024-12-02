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

    // TODO: Manager에서 접근하여 호출하는 하위 클래스의 메서드는 참조 없이 이벤트로 호출한다. 
    public static UnityEvent<(string, string)> OnItemInfoPanelUpdate;
    public static UnityEvent OnInventoryInfoPanelUpdate;
    public static UnityEvent OnItemUse;


    public override void Init() {
        PanelUpdateItemInfo(("인벤토리", "아이템 항목을 선택하면 세부 사항을 볼 수 있습니다."));
        
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
        this.inventorySpaceIndicator.value = PlayerBehaviourManager.Instance.UpdateInventoryAmountTotal();
        this.inventorySpaceIndicator.maxValue = PlayerBehaviourManager.Instance.InventorySpaceMax;
        this.inventorySpaceText.text = PlayerBehaviourManager.Instance.InventorySpace + " / " + PlayerBehaviourManager.Instance.InventorySpaceMax;
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
