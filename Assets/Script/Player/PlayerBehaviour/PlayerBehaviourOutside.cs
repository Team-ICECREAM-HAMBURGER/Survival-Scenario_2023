using UnityEngine;

public class PlayerBehaviourOutside : PlayerBehaviour {
    [Space(25f)] 

    [Header("Game Screen Update Resource")] 
    [SerializeField] private Canvas shelterCanvas;
    [SerializeField] private Canvas outsideCanvas;
    
    private string currentLocationText;
    
    
    public override void Init() {
        this.currentLocationText = "산기슭";
    }

    public override void Behaviour() {
        PanelUpdate();
        PlayerBehaviourManager.Instance.WorldCurrentLocationUpdate(this.currentLocationText);
    }
    
    private void PanelUpdate() {
        this.shelterCanvas.enabled = false;
        this.outsideCanvas.enabled = true;
    }
}