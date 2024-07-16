using UnityEngine;

public class PlayerBehaviourManager : GameControlSingleton<PlayerBehaviourManager> {
    [field: SerializeField] public GameControlDictionary.PlayerBehaviour Behaviour { get; private set; }
    
    
    public void Init() {
        foreach (var VARIABLE in this.Behaviour) {
            VARIABLE.Value.Init();
        }
    }
}