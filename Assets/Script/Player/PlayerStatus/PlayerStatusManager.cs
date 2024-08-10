using UnityEngine;
using UnityEngine.Events;

public class PlayerStatusManager : GameControlSingleton<PlayerStatusManager> {
    [field: SerializeField] public GameControlDictionary.PlayerStatus Statuses { get; private set; }
    
    [Space(25f)]

    [SerializeField] private UnityEvent OnPlayerStatusInit;
    
    
    public void Init() {
        this.OnPlayerStatusInit.Invoke();
    }
}