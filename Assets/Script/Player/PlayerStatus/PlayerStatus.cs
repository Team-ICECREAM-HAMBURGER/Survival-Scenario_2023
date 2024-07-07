using UnityEngine;

public abstract class PlayerStatus : MonoBehaviour {
    public string Name { get; protected set; }
    public GameControlType.Status Type { get; protected set; }
    public float LimitValue { get; protected set; }
    public float CurrentValue { get; protected set; }
    
    
    public abstract void Init();
    public abstract void StatusUpdate(float value);
}