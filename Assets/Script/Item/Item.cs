using TMPro;
using UnityEngine;

public abstract class Item : MonoBehaviour {
    [Header("Item Information")]
    public GameControlType.Item itemType;
    public string itemInfoTitleText;
    public string itemInfoExplanationText;
    
    [Space(25f)]
    
    [Header("UI Component")]
    [SerializeField] protected TMP_Text itemName;
    [SerializeField] protected TMP_Text itemAmount;

    public TMP_Text itemInfoTitle;
    public TMP_Text itemInfoExplanation;
    
    
    public virtual void Init() {
        ItemManager.Instance.OnInventorySync.AddListener(InventorySync);
        
        itemInfoTitle = ItemManager.Instance.itemInfoTitle;
        itemInfoExplanation = ItemManager.Instance.itemInfoExplanation;
    }

    public virtual void ItemInfo() {
        itemInfoTitle.text = itemInfoTitleText;
        itemInfoExplanation.text = itemInfoExplanationText;
    }
    
    public virtual void InventorySync(GameControlDictionary.Inventory value) {
        if (value.ContainsKey(itemType) && value[itemType] > 0) {
            gameObject.SetActive(true);
        }
        else {
            gameObject.SetActive(false);
        }
        
        itemAmount.text = value[itemType].ToString();
        
        itemInfoTitle.text = "인벤토리";
        itemInfoExplanation.text = "아이템 항목을 선택하면 상세 설명을 볼 수 있습니다.";
    }
    
    public abstract void ItemUse(int value = 1);
    public abstract void ItemDrop(int value = 1);
    public abstract void ItemAdd(int value = 1);
}