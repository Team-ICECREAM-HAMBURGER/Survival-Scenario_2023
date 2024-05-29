using UnityEngine;

public class PlayerBehaviourInventory : MonoBehaviour, IPlayerBehaviour {
    public void Init() {
    }
    
    public void Behaviour() {
        foreach (var VARIABLE in Player.Instance.Inventory) {
            ItemManager.Instance.Items[VARIABLE.Key].InventoryCountUpdate(VARIABLE.Value > 0 ? VARIABLE.Value : 0);
        }
    }

    private void PanelUpdate() {
    }
}
