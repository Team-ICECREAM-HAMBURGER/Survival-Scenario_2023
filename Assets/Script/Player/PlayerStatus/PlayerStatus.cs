using UnityEngine;

public abstract class PlayerStatus : MonoBehaviour {
    public string Name { get; protected set; }
    public GameControlType.Status Type { get; protected set; }
    public float LimitValue { get; protected set; }
    public float CurrentValue { get; protected set; }


    public virtual void Init() {
        GameInformationMonitorPlayer.OnStatusGaugeUpdate.Invoke(this.Type, this.CurrentValue);
    }

    public virtual void StatusUpdate(float value) {
        this.CurrentValue = Mathf.Clamp(this.CurrentValue + value, 0f, 100f);
        Player.Instance.Status[this.Type] = this.CurrentValue;
        
        GameInformationMonitorPlayer.OnStatusGaugeUpdate.Invoke(this.Type, this.CurrentValue);
    }
}