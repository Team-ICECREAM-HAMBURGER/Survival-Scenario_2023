using UnityEngine;

public class PlayerBehaviourOutside : PlayerBehaviour {
    public override void Init() {
    }

    public override void Behaviour() {
        PanelUpdate();
        
        WorldInformation.OnCurrentLocationUpdate.Invoke(World.Instance.Location);
    }
    
    private void PanelUpdate() {
    }
}