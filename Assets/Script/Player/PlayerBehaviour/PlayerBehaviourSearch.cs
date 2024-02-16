using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourSearch : MonoBehaviour, IPlayerBehaviour {   // Presenter
    public bool BehaviourCheck() {
        return true;
    }
    
    public void Behaviour() {
        if (BehaviourCheck()) {
            return;
        }
        
        // Player Status Update
        Player.Instance.StatusUpdate(-20f, -10f, -10f, -10f);
        
        // Random Event
        BehaviourRandomEvent();
    }

    private void BehaviourRandomEvent() {
        var randomPivot = Random.Range(0f, 100f);
        var weight = 0f;
        
        
        
        
    }
    
    public void UpdateView() {
    }
}