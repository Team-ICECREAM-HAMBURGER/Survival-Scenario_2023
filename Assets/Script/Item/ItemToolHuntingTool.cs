using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToolHuntingTool : ItemTool {
    public override void ItemUse(int value = 1) {
        Player.Instance.InventoryUpdate(ItemType, -value);
    }

    public override void ItemDrop(int value = 1) {
        Player.Instance.InventoryUpdate(ItemType, -value);
    }

    public override void ItemAdd(int value = 1) {
        Player.Instance.InventoryUpdate(ItemType, value);
    }
}
