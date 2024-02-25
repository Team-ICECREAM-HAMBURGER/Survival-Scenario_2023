using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {  // Presenter
    public delegate void ItemEventHandler();
    public static ItemEventHandler OnItemUse;
    public static ItemEventHandler OnItemCraft;


    private void Init() {
        OnItemUse += ItemUse;
        OnItemCraft += ItemCraft;
    }

    private void Awake() {
        Init();
    }

    private void ItemUse() {
    }

    private void ItemCraft() {
    }
}