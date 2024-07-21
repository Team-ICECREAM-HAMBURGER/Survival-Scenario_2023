using TMPro;
using UnityEngine;

public abstract class Item : MonoBehaviour {
    public GameControlType.Item ItemType { get; }
    public GameControlType.ItemGetRoot ItemGetType { get; }
    public string Name { get; }
    public string Content { get; }
    
    public float RandomPercent { get; }
    public float RandomWeight { get; set; }
    public int RandomMaxValue { get; }

    public TMP_Text InventoryNameText { get; }
    public TMP_Text InventoryCountText { get; }


    public void Init(Transform content) {
        ItemManager.Instance.OnItemCountUpdate.AddListener(ItemCountUpdate);
    }

    public void InventoryInfoUpdate() {
        
    }

    public abstract void ItemCountUpdate();
    public abstract void ItemUse(int value = 1);
    public abstract void ItemDrop(int value = 1);
    public abstract void ItemAdd(int value = 1);
}