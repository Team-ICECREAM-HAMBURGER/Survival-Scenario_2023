using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ItemMaterial : MonoBehaviour, IItem {
    [field: SerializeField] public GameControlType.Item ItemType { get; set; }
    [field: SerializeField] public GameControlType.Behaviour ItemGetType { get; set; }

    [field: SerializeField] public string Name { get; set; }
    [field: SerializeField] public string Content { get; set; }
    [field: SerializeField] public float RandomPercent { get; private set; }
    [field: SerializeField] public float RandomWeight { get; set; }
    [field: SerializeField] public int RandomMaxValue { get; private set; }
    
    [field: SerializeField] public TMP_Text InventoryNameText { get; private set; }
    [field: SerializeField] public TMP_Text InventoryCountText { get; private set; }
    
    [Space(25f)]
    
    [SerializeField] private Button itemInfoButton;
    [SerializeField] private Button itemDropButton;
    
    private GameObject obj;
    private ItemMaterial item;
    
    
    public void Init(Transform content) {
        this.obj = Instantiate(gameObject, content);
        this.item = this.obj.GetComponent<ItemMaterial>();
        this.item.InventoryNameText.text = this.Name;
        this.item.InventoryCountText.text = "0개";
        
        this.item.itemInfoButton.onClick.AddListener(InventoryInfoUpdate);
        this.item.itemDropButton.onClick.AddListener(() => {
            ItemDrop();
            PlayerBehaviourInventory.OnItemUpdate.Invoke();
        });
        
        this.obj.SetActive(false);
    }

    public void InventoryCountUpdate(int value) {
        this.item.InventoryCountText.text = value + "개";
        this.obj.SetActive(value > 0);
    }

    public void InventoryInfoUpdate() {
        PlayerBehaviourInventory.OnItemInfoUpdate.Invoke(this.Name, this.Content);
    }
    
    public abstract void ItemUse(int value = 1);
    public abstract void ItemDrop(int value = 1);
    public abstract void ItemAdd(int value = 1);
}