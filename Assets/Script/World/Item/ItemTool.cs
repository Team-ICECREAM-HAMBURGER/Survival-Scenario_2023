using TMPro;
using UnityEngine;

public class ItemTool : MonoBehaviour, IItem {
    [field: SerializeField] public GameControlType.Item Type { get; set; }
    [field: SerializeField] public string Name { get; set; }
    [field: SerializeField] public string Content { get; set; }
    [field: SerializeField] public float RandomPercent { get; private set; }
    [field: SerializeField] public float RandomWeight { get; private set; }
    [field: SerializeField] public int RandomMaxValue { get; private set; }
    
    [field: SerializeField] public TMP_Text InventoryNameText { get; private set; }
    [field: SerializeField] public TMP_Text InventoryCountText { get; private set; }
    
    private GameObject obj;
    private ItemTool itemTool;
    
    
    public void Init(float value, Transform content) {
        this.RandomWeight = (this.RandomPercent / value);
        
        this.obj = Instantiate(gameObject, content);
        this.itemTool = this.obj.GetComponent<ItemTool>();
        this.itemTool.InventoryNameText.text = this.Name;
        this.itemTool.InventoryCountText.text = "0개";
        
        this.obj.SetActive(false);
    }


    public void InventoryCountUpdate(int value) {
        this.itemTool.InventoryCountText.text = value + "개";
        this.obj.SetActive(value > 0);
    }
}