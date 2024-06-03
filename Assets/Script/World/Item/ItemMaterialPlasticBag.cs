public class ItemMaterialPlasticBag : ItemMaterial {
    public override void ItemDrop() {
        Player.Instance.InventoryUpdate(Type, -1);
        PlayerBehaviourInventory.OnItemUse.Invoke();
    }
}
