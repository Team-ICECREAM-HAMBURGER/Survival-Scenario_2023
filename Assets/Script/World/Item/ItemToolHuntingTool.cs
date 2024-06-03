using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToolHuntingTool : ItemTool {
    public override void ItemDrop() {
        Player.Instance.InventoryUpdate(Type, -1);
        PlayerBehaviourInventory.OnItemUse.Invoke();
    }
}
