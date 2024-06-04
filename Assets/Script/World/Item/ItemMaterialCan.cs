public class ItemMaterialCan : ItemMaterial {
    public override void ItemDrop() {
        Player.Instance.InventoryUpdate(Type, -1);
        PlayerBehaviourInventory.OnItemUpdate.Invoke();
    }
}
