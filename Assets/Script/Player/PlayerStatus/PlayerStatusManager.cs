using UnityEngine;

public class PlayerStatusManager : GameControlSingleton<PlayerStatusManager> {
    [field: SerializeField] public GameControlDictionary.PlayerStatus Statuses { get; private set; }
    
    
    public void Init() {
        foreach (var VARIABLE in this.Statuses) {
            VARIABLE.Value.Init();
        }
    }
}