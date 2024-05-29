using TMPro;
using UnityEngine;

public class ItemMaterial : MonoBehaviour, IItem {
    [field: SerializeField] public GameControlType.Item Type { get; set; }
    [field: SerializeField] public string Name { get; set; }
    [field: SerializeField] public string Content { get; set; }
    [field: SerializeField] public float RandomPercent { get; private set; }
    [field: SerializeField] public float RandomWeight { get; private set; }
    [field: SerializeField] public int RandomMaxValue { get; private set; }
    
    [field: SerializeField] public TMP_Text InventoryNameText { get; private set; }
    [field: SerializeField] public TMP_Text InventoryCountText { get; private set; }
    
    private GameObject obj;
    private ItemMaterial itemMaterial;
    
    
    public void Init(float value, Transform content) {
        this.RandomWeight = (this.RandomPercent / value);
        
        this.obj = Instantiate(gameObject, content);
        this.itemMaterial = this.obj.GetComponent<ItemMaterial>();
        this.itemMaterial.InventoryNameText.text = this.Name;
        this.itemMaterial.InventoryCountText.text = "0개";
        
        this.obj.SetActive(false);
    }

    public void InventoryCountUpdate(int value) {
        this.itemMaterial.InventoryCountText.text = value + "개";
        this.obj.SetActive(value > 0);
    }
}