using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToolFireTool : ItemTool {
    public override void ItemDrop() {
        Player.Instance.InventoryUpdate(Type, -1);
        PlayerBehaviourInventory.OnItemUpdate.Invoke();
    }
}
