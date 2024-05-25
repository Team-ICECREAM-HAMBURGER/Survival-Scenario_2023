using UnityEngine;

public class PlayerBehaviourOutside : MonoBehaviour, IPlayerBehaviour {
    public void Behaviour() {
        PanelUpdate();
        
        WorldInformationViewer.OnCurrentTimeDayUpdate.Invoke(World.Instance.TimeDay);
        WorldInformationViewer.OnCurrentLocationUpdate.Invoke(World.Instance.Location);
    }
    
    private void PanelUpdate() {
    }
}