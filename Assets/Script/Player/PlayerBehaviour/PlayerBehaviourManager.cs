using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBehaviourManager : GameControlSingleton<PlayerBehaviourManager> {
    [field: SerializeField] public GameControlDictionary.PlayerBehaviour Behaviour { get; private set; }
    
    [Space(25f)]

    [SerializeField] private UnityEvent OnPlayerBehaviourInit;

    
    public void Init() {
        this.OnPlayerBehaviourInit = new();
        this.OnPlayerBehaviourInit.Invoke();
    }
    
    public bool CanBehaviour(List<(GameControlType.Item, int)> values) {
        return values.All(VARIABLE => Player.Instance.Inventory[VARIABLE.Item1] >= VARIABLE.Item2);
    }
    
    public bool CanBehaviour((GameControlType.Item, int) value) {
        return (Player.Instance.Inventory[value.Item1] >= value.Item2);
    }

    public void InventoryInvoke() {
        ItemManager.Instance.ItemCountUpdate();
    }

    public void ItemUse((GameControlType.Item, int) value) {
        ItemManager.Instance.ItemUse(value);
    }

    public void ItemAdd((GameControlType.Item, int) value) {
        ItemManager.Instance.ItemAdd(value);
    }

    public void RandomEvent() {
        GameRandomEventManager.Instance.RandomEventWeightSelect();
    }
}