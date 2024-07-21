using UnityEngine;

public class PlayerBehaviourOutside : PlayerBehaviour {
    public override void Init() {
    }

    public override void Behaviour() {
        PanelUpdate();
        
        GameInformationMonitorWorld.OnCurrentLocationUpdate.Invoke(World.Instance.Location);
    }
    
    private void PanelUpdate() {
    }
}