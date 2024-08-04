using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Item : MonoBehaviour {
    [HideInInspector] public GameObject itemObject;
    [HideInInspector] public Item itemObjectComponent;
    
    public GameControlType.Item itemType;
    public string itemNameText;
    public string itemExplanationText;
    
    [Space(25f)]
    
    [SerializeField] protected TMP_Text itemName;
    [SerializeField] protected TMP_Text itemAmount;

    
    public virtual void Init() {
        ItemManager.Instance.OnInventorySync.AddListener(InventorySync);
        
        itemObject = Instantiate(gameObject, GameObject.FindGameObjectWithTag("Inventory").transform);
        itemObjectComponent = itemObject.GetComponent<Item>();
    }
    
    public virtual void InventorySync(GameControlDictionary.Inventory value) {
        if (value.ContainsKey(itemType) && value[itemType] > 0) {
            itemObject.SetActive(true);
        }
        else {
            itemObject.SetActive(false);
        }
        
        itemObjectComponent.itemName.text = itemNameText;
        itemObjectComponent.itemAmount.text = value[itemType].ToString();
    }
    
    public abstract void ItemUse(int value = 1);
    public abstract void ItemDrop(int value = 1);
    public abstract void ItemAdd(int value = 1);
}