using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBehaviourInventory : MonoBehaviour, IPlayerBehaviour {
    [Header("Item Information Panel")]
    [SerializeField] private TMP_Text itemInfoTitle;
    [SerializeField] private TMP_Text itemInfoContent;
    
    public static UnityEvent<string, string> OnItemInfoUpdate;
    public static UnityEvent OnItemUse;
    public static UnityEvent OnItemDrop;


    public void Init() {
        OnItemInfoUpdate = new();
        OnItemInfoUpdate.AddListener(PanelUpdate);

        OnItemUse = new();
        OnItemUse.AddListener(Behaviour);

        OnItemDrop = new();
        OnItemDrop.AddListener(Behaviour);
    }

    public void Behaviour() {
        foreach (var VARIABLE in Player.Instance.Inventory) {
            ItemManager.Instance.Items[VARIABLE.Key].InventoryCountUpdate(VARIABLE.Value > 0 ? VARIABLE.Value : 0);
        }
        
        World.Instance.WorldTimeUpdate(0);
    }

    private void PanelUpdate(string title, string content) {
        this.itemInfoTitle.text = title;
        this.itemInfoContent.text = content;
    }
}
