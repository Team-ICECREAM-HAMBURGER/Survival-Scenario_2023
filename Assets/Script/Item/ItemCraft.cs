using TMPro;
using UnityEngine;

public class ItemCraft : MonoBehaviour {
    [Header("Item Information")] 
    public GameControlType.Item itemType;
    public int itemCraftAmount = 1;
    public string itemInfoTitleText;
    [TextArea] public string itemInfoExplanationText;
    
    [Space(25f)] 
    
    [Header("UI Component")] 
    [SerializeField] protected TMP_Text itemName;
    [SerializeField] protected TMP_Text itemAmount;
    
    [Space(10f)]
    
    [SerializeField] protected TMP_Text itemInfoTitle;
    [SerializeField] protected TMP_Text itemInfoExplanation;


    private void Init() {
        ItemManager.Instance.OnInventorySync.AddListener(InventorySync);
    }

    private void Awake() {
        Init();
    }
    
    public void InventorySync(GameControlDictionary.Inventory value) {
        this.itemAmount.text = value[this.itemType].ToString();
    }
    
    public void Craft() { 
        // TODO: 메서드 제작
        ItemManager.Instance.ItemAdd((this.itemType, this.itemCraftAmount));
        ItemManager.Instance.InventorySync();
    }

    public void ItemInfo() {
        this.itemInfoTitle.text = this.itemInfoTitleText;
        this.itemInfoExplanation.text = this.itemInfoExplanationText;
    }
}