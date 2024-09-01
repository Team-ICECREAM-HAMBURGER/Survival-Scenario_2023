using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

// Manager -> Inside : Event or Reference
// Outside -> Manager : Method

public class ItemManager : GameControlSingleton<ItemManager> {  // Model
    [field: SerializeField] private GameControlDictionary.Item ItemPrefab { get; set; }
    [HideInInspector] public GameControlDictionary.Item ItemObject { get; private set; }
    [HideInInspector] public UnityEvent<GameControlDictionary.Inventory> OnInventorySync;

    [Space(25f)]

    [Header("UI Component")]
    public TMP_Text itemInfoTitle;
    public TMP_Text itemInfoExplanation;
    public Transform itemInventoryListViewContent;
    
    
    private void Init() {
        this.ItemObject = new();
        
        // Items Init
        foreach (var VARIABLE in this.ItemPrefab) {
            Instantiate(VARIABLE.Value.gameObject, this.itemInventoryListViewContent);
        }
    }
    
    private void Awake() {
        Init();
    }

    public void InventorySync() {
        this.OnInventorySync.Invoke(Player.Instance.Inventory);
        PlayerBehaviourManager.Instance.GameDataSaveInvoke();
        PlayerBehaviourManager.Instance.PanelUpdateInventoryInfo();
    }

    public string ItemUse((GameControlType.Item, int) value) {
        this.ItemObject[value.Item1].ItemUse(value.Item2);
        
        return this.ItemObject[value.Item1].itemInfoTitleText;
    }

    public string ItemAdd((GameControlType.Item, int) value) {
        this.ItemObject[value.Item1].ItemAdd(value);

        return this.ItemObject[value.Item1].itemInfoTitleText;
    }

    public string ItemDrop((GameControlType.Item, int) value) {
        this.ItemObject[value.Item1].ItemUse(value.Item2);
        
        return this.ItemObject[value.Item1].itemInfoTitleText;
    }
    
    public string GetItemName(GameControlType.Item type) {
        return this.ItemObject[type].itemInfoTitleText;
    }

    public void ItemEffectStatusUpdate(List<(GameControlType.Status, float)> value) {
        PlayerStatusManager.Instance.StatusUpdate(value);
    }
}