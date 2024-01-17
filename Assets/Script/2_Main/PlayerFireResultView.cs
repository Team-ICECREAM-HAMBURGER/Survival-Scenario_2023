using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFireResultView : MonoBehaviour {
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text contentText;
    [SerializeField] private Button okButton;
    
    public delegate void FireResultUIUpdateHandler(string value);
    public static FireResultUIUpdateHandler OnFireResultSuccess;
    public static FireResultUIUpdateHandler OnFireResultFail;

    
    private void Init() {
        OnFireResultSuccess += FireResultSuccess;
        OnFireResultFail += FireResultFail;
    }

    private void Awake() {
        Init();
    }

    private void FireResultSuccess(string value) {
        this.titleText.text = "불이 붙었다.";
        this.contentText.text = value;
        
        this.okButton.onClick.AddListener(MakingFireResultSuccess);
    }

    private void FireResultFail(string value) {
        this.titleText.text = "불을 붙이지 못했다.";
        this.contentText.text = value;
        
        this.okButton.onClick.AddListener(MakingFireResultFail);
    }
    
    private void MakingFireResultSuccess() {
        GameCanvasControl.OnCanvasOnEvent("Canvas Information");
        GamePanelControl.OnGamePanelOffEvent("Fire Result");
        GamePanelControl.OnGamePanelOnEvent("Fire Menu");
    }

    private void MakingFireResultFail() {
        GameCanvasControl.OnCanvasChangeEvent("Canvas Outside");
        GameCanvasControl.OnCanvasOnEvent("Canvas Information");
    }
}