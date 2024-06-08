public class ItemFoodBottleOfWater : ItemFood {
    public override void ItemUse() {
        Player.Instance.StatusUpdate(stamina, bodyHeat, hydration, calories);
        Player.Instance.InventoryUpdate(Type, -1);
        PlayerBehaviourInventory.OnItemUpdate.Invoke();
    }

    public override void ItemDrop() {
        Player.Instance.InventoryUpdate(Type, -1);
        PlayerBehaviourInventory.OnItemUpdate.Invoke();
    }
}
