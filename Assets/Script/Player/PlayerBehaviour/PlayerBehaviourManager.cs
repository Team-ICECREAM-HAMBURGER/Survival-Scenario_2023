using System.Linq;
using UnityEngine;

public class PlayerBehaviourManager : GameControlSingleton<PlayerBehaviourManager> {
    private void Init() {
    }

    private void Awake() {
        Init();
    }
    
    public bool CanBehaviour(GameControlDictionary.RequireItem requireItem) {
        return (requireItem.All(item => 
            Player.Instance.Inventory[item.Key] >= Mathf.Abs(requireItem[item.Key]))
            );
    }
}