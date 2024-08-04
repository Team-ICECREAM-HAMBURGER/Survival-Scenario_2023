using UnityEngine;
using UnityEngine.Events;

public class ItemManager : GameControlSingleton<ItemManager> {  // Model
    [field: SerializeField] public GameControlDictionary.Item Item { get; private set; }
    
    [Space(25f)]
    
    [SerializeField] private UnityEvent OnItemInit;
    
    [HideInInspector] public UnityEvent<GameControlDictionary.Inventory> OnInventorySync;
    
    
    private void Init() {
        // Items Init
        this.OnItemInit.Invoke();
    }
    
    private void Awake() {
        Init();
    }

    public void InventorySync(GameControlDictionary.Inventory value) {
        this.OnInventorySync.Invoke(value);
    }

    public void ItemUse((GameControlType.Item, int) value) {
        if (Player.Instance.Inventory.ContainsKey(value.Item1) && Player.Instance.Inventory[value.Item1] >= value.Item2) {
            this.Item[value.Item1].ItemUse(value.Item2);
        }
    }

    public string ItemAdd((GameControlType.Item, int) value) {
        this.Item[value.Item1].ItemAdd(value.Item2);
        Player.Instance.Inventory[value.Item1] += value.Item2;
        
        return this.Item[value.Item1].itemNameText;
    }

    public string GetItemName(GameControlType.Item type) {
        return this.Item[type].itemNameText;
    }
}