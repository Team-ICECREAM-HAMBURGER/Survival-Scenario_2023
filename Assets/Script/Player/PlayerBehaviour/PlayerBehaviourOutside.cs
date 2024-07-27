public class PlayerBehaviourOutside : PlayerBehaviour {
    private string currentLocationText;
    
    
    public override void Init() {
        this.currentLocationText = "산기슭";
    }

    public override void Behaviour() {
        PlayerBehaviourManager.Instance.WorldCurrentLocationUpdate(this.currentLocationText);
    }
    
    private void PanelUpdate() {
    }
}