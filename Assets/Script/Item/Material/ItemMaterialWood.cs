using UnityEngine;

public class ItemMaterialWood : MonoBehaviour, IItemMaterial {
    public GameTypeItem ItemType { get; private set; }
    public string ItemName { get; private set; }
    [field: SerializeField] public int ItemQuantity { get; set; }
    public float RandomWeight { get; set; }
    public int MaxAcquireValue { get; private set; }


    private void Init() {
        this.ItemType = GameTypeItem.MATERIAL;
        this.ItemName = "나무";
        this.ItemQuantity = 0;
        this.RandomWeight = 90f;
        this.MaxAcquireValue = 3;
        
        ItemSpawnManager.OnMaterialItemRandomGet += () => { this.ItemQuantity = 0; };
    }

    private void Awake() {
        Init();
    }
}