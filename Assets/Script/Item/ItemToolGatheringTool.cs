using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToolGatheringTool : ItemTool {
    public override void ItemDrop() {
        Player.Instance.InventoryUpdate(ItemType, -1);
        PlayerBehaviourInventory.OnItemUpdate.Invoke();
    }
}