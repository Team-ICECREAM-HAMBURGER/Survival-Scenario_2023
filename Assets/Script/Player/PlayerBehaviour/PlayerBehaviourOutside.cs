using UnityEngine;

public class PlayerBehaviourOutside : MonoBehaviour, IPlayerBehaviour {
    public void Init() {
    }

    public void Behaviour() {
        PanelUpdate();
        
        // WorldInformation.OnCurrentTimeDayCounterUpdate.Invoke(World.Instance.TimeDay);
        WorldInformation.OnCurrentLocationUpdate.Invoke(World.Instance.Location);
    }
    
    private void PanelUpdate() {
    }
}