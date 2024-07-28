using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Item : MonoBehaviour {
    public GameControlType.Item ItemType { get; protected set; }
    public string ItemNameText { get; protected set; }
    public string ItemExplanationText { get; protected set; }

    [SerializeField] protected TMP_Text itemName;
    [SerializeField] protected TMP_Text itemAmount;

    
    public virtual void Init() {
        ItemManager.Instance.OnInventorySync.AddListener(InventorySync);
        Instantiate(gameObject, GameObject.FindGameObjectWithTag("Inventory").transform);
    }
    
    public virtual void InventorySync(GameControlDictionary.Inventory value) {
        if (value.ContainsKey(ItemType) && value[ItemType] > 0) {
            gameObject.SetActive(true);
            
            itemName.text = ItemNameText;
            itemAmount.text = value[ItemType].ToString();
        }
        else {
            gameObject.SetActive(false);
        }
    }
    
    public abstract void ItemUse(int value = 1);
    public abstract void ItemDrop(int value = 1);
    public abstract void ItemAdd(int value = 1);
}