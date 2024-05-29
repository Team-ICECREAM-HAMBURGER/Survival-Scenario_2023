using TMPro;
using UnityEngine;

public class ItemFood : MonoBehaviour, IItem {
    [field: SerializeField] public GameControlType.Item Type { get; set; }
    [field: SerializeField] public string Name { get; set; }
    [field: SerializeField] public string Content { get; set; }
    [field: SerializeField] public float RandomPercent { get; private set; }
    [field: SerializeField] public float RandomWeight { get; private set; }
    [field: SerializeField] public int RandomMaxValue { get; private set; }

    [field: SerializeField] public TMP_Text InventoryNameText { get; private set; }
    [field: SerializeField] public TMP_Text InventoryCountText { get; private set; }
    
    private GameObject obj;
    private ItemFood itemFood;
    
    
    public void Init(float value, Transform content) {
        this.RandomWeight = (this.RandomPercent / value);
        
        this.obj = Instantiate(gameObject, content);
        this.itemFood = this.obj.GetComponent<ItemFood>();
        this.itemFood.InventoryNameText.text = this.Name;
        this.itemFood.InventoryCountText.text = "0개";
        
        this.obj.SetActive(false);
    }


    public void InventoryCountUpdate(int value) {
        this.itemFood.InventoryCountText.text = value + "개";
        this.obj.SetActive(value > 0);
    }
}