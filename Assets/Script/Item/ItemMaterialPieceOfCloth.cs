public class ItemMaterialPieceOfCloth : ItemMaterial {
    public override void ItemDrop() {
        Player.Instance.InventoryUpdate(ItemType, -1);
        PlayerBehaviourInventory.OnItemUpdate.Invoke();
    }
}
