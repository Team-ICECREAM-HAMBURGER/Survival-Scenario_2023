using UnityEngine;
using UnityEngine.Events;

public class GameRandomEventManager : GameControlSingleton<GameRandomEventManager> {
    [field: SerializeField] public GameControlDictionary.GameRandomEvent RandomEvent { get; private set; }

    [Space(25f)]
    
    [SerializeField] private UnityEvent OnRandomEventInit;
    
    
    private void Init() {
        
    }

    private void Awake() {
        Init();
    }
    
    public void RandomEventWeightSelect() {
        // TODO: 2024.07.21 --
    }
}