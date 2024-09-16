using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

// Manager -> Inside : Event or Reference
// Outside -> Manager : Method

public class ItemManager : GameControlSingleton<ItemManager> {  // Model
    private GameControlDictionary.Item items;

    public UnityEvent<GameControlDictionary.Inventory> OnInventorySync;


    private void Init() {
        this.items = new();
    }

    public void ItemsAdd((GameControlType.Item, Item) value) {
        this.items.TryAdd(value.Item1, value.Item2);
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
        this.items[value.Item1].ItemUse(value.Item2);
        
        return this.items[value.Item1].itemInfoTitleText;
    }

    public string ItemAdd((GameControlType.Item, int) value) {
        this.items[value.Item1].ItemAdd(value);

        return this.items[value.Item1].itemInfoTitleText;
    }

    public string ItemDrop((GameControlType.Item, int) value) {
        this.items[value.Item1].ItemUse(value.Item2);
        
        return this.items[value.Item1].itemInfoTitleText;
    }
    
    public string GetItemName(GameControlType.Item type) {
        return this.items[type].itemInfoTitleText;
    }

    public void ItemEffectStatusUpdate(List<(GameControlType.Status, float)> value) {
        PlayerStatusManager.Instance.StatusUpdate(value);
    }
}