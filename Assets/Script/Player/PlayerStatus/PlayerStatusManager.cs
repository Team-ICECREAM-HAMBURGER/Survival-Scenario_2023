using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStatusManager : GameControlSingleton<PlayerStatusManager> {
    [field: SerializeField] public GameControlDictionary.PlayerStatus Status { get; private set; }
    
    [Space(25f)]

    [SerializeField] private UnityEvent OnPlayerStatusInit;
    
    
    public void Init() {
        this.OnPlayerStatusInit.Invoke();
    }

    public void StatusUpdate((GameControlType.Status, float) value) {
        this.Status[value.Item1].StatusUpdate(value.Item2);
    }

    public void StatusUpdate(List<(GameControlType.Status, float)> value) {
        foreach (var VARIABLE in value) {
            this.Status[VARIABLE.Item1].StatusUpdate(VARIABLE.Item2);
        }
    }
}