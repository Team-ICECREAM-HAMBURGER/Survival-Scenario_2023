public class ItemFoodBerry : ItemFood {
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