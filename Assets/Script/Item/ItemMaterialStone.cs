public class ItemMaterialStone : ItemMaterial {
    public override void ItemDrop() {
        Player.Instance.InventoryUpdate(Type, -1);
        PlayerBehaviourInventory.OnItemUpdate.Invoke();
    }
}
