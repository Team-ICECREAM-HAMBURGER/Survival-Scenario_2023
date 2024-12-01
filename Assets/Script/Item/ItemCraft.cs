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


    public void Init() {
        this.itemInfoTitle.text = this.itemInfoTitleText;
        this.itemInfoExplanation.text = this.itemInfoExplanationText;

        InventorySync();
    }

    private void InventorySync() {  // TODO: PlayerBehaviourCraft.Behaviour() 단계에서 실행되어야 개수가 업데이트된다.
        this.itemAmount.text = Player.Instance.Inventory[this.itemType].ToString();
    }
    
    public void Craft() {
        ItemManager.Instance.ItemAdd((this.itemType, this.itemCraftAmount));
    }
}