using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemFoodBerry : ItemFood {
    [SerializeField] private float stamina;
    [SerializeField] private float bodyHeat;
    [SerializeField] private float hydration;
    [SerializeField] private float calories;
    
    
    public override void ItemUse() {
        Player.Instance.StatusUpdate(this.stamina, this.bodyHeat, this.hydration, this.calories);
        Player.Instance.InventoryUpdate(this.Type, -1);
        PlayerBehaviourInventory.OnItemUse.Invoke();
    }

    public override void ItemDrop() {
    }
}