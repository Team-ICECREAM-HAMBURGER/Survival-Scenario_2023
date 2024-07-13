using UnityEngine;

public class PlayerBehaviourOutside : MonoBehaviour, IPlayerBehaviour {
    public void Init() {
    }

    public void Behaviour() {
        PanelUpdate();
        
        WorldInformation.OnCurrentLocationUpdate.Invoke(World.Instance.Location);
    }
    
    private void PanelUpdate() {
    }
}