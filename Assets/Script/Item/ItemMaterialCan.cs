public class ItemMaterialCan : ItemMaterial {
    public override void ItemDrop() {
        Player.Instance.InventoryUpdate(ItemType, -1);
        PlayerBehaviourInventory.OnItemUpdate.Invoke();
    }
}
