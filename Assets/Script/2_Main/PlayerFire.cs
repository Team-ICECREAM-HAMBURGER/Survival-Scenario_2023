using UnityEngine;

public class PlayerFire : MonoBehaviour {
    [SerializeField] private GameObject makingFireScreen;

    public delegate void MakingFireEventHandler();
    public static MakingFireEventHandler OnMakingFireEvent;
    
    
    private void Init() {
        OnMakingFireEvent += MakingFire;
    }
    
    private void Start() {
        Init();
    }

    private void MakingFire() {
        GameCanvasControl.OnCanvasChangeEvent("Canvas Fire");
        this.makingFireScreen.SetActive(true);
        
        // Random
        
    }


    private void MakingFireResult() {
        
    }
}
