using System;
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
    
    [Space(10f)]
    
    [SerializeField] protected TMP_Text itemInfoTitle;
    [SerializeField] protected TMP_Text itemInfoExplanation;
    
    
    public virtual void Init() { 
        ItemManager.Instance.OnInventorySync.AddListener(InventorySync);
        ItemManager.Instance.ItemsAdd((this.itemType, this));
    }

    private void Awake() {
        Init();
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
    
    public virtual void ItemUse(int value) { // GUI Button
        if (Player.Instance.Inventory.ContainsKey(this.itemType) && Player.Instance.Inventory[this.itemType] >= value) {
            Player.Instance.Inventory[this.itemType] -= value;
        }
    }

    public virtual void ItemDrop(int value) { // GUI Button
        if (Player.Instance.Inventory.ContainsKey(this.itemType) && Player.Instance.Inventory[this.itemType] >= value) {
            Player.Instance.Inventory[this.itemType] -= value;
        }
        
        ItemManager.Instance.InventorySync();
    }

    public virtual void ItemAdd((GameControlType.Item, int) value) {    // Event
        Player.Instance.Inventory[value.Item1] += value.Item2;   
    }
}