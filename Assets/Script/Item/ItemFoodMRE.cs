public class ItemFoodMRE : ItemFood {
    public override void ItemUse() {
        Player.Instance.StatusUpdate(requireStatuses, +1);
        Player.Instance.InventoryUpdate(Type, -1);
        PlayerBehaviourInventory.OnItemUpdate.Invoke();
    }

    public override void ItemDrop() {
        Player.Instance.InventoryUpdate(Type, -1);
        PlayerBehaviourInventory.OnItemUpdate.Invoke();
    }
}