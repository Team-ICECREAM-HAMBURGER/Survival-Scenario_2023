using UnityEngine;
using UnityEngine.Events;

public abstract class PlayerBehaviour : MonoBehaviour {
    [Header("Behaviour Require Status")]
    public UnityEvent OnPlayerStatusUpdate;

    public int behaviourSpendTime;
    
    
    public abstract void Init();
    public abstract void Behaviour();
}