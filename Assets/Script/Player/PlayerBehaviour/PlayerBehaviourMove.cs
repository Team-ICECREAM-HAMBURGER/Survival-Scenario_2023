using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourMove : MonoBehaviour, IPlayerBehaviour {
    private float requireStatusValue;
    
    
    private void Init() {
        this.requireStatusValue = 50f;
    }

    private void Awake() {
        Init();
    }

    public bool CanBehaviour() {
        return true;
    }


    public void Behaviour() {
        throw new System.NotImplementedException();
    }

    public bool BehaviourCheck() {
        throw new System.NotImplementedException();
    }

    public void UpdateView() {
        // Canvas Change
    }
}