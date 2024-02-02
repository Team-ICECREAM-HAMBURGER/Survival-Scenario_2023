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
    public static FireResultUIUpdateHandler OnCookingResult;

    
    private void Init() {
        OnFireResultSuccess += FireResultSuccess;
        OnFireResultFail += FireResultFail;
        OnCookingResult += CookingResult;
    }

    private void Awake() {
        Init();
    }

    private void FireResultSuccess(string value) {
        this.titleText.text = "불이 붙었다.";
        this.contentText.text = value;
        
        this.okButton.onClick.RemoveAllListeners();
        this.okButton.onClick.AddListener(FireResultSuccessListener);
    }

    private void FireResultFail(string value) {
        this.titleText.text = "불을 붙이지 못했다.";
        this.contentText.text = value;
        
        this.okButton.onClick.RemoveAllListeners();
        this.okButton.onClick.AddListener(FireResultFailListener);
    }

    private void CookingResult(string value) {
        this.titleText.text = "조리 완료";
        this.contentText.text = value;
        
        GamePanelControl.OnGamePanelOnEvent("Fire Result");
        
        this.okButton.onClick.RemoveAllListeners();
        this.okButton.onClick.AddListener(CookingResultListener);
    }

    private void CookingResultListener() {
        GameCanvasControl.OnCanvasOnEvent("Canvas Information");
        GamePanelControl.OnGamePanelOffEvent("Fire Result");
    }
    
    private void FireResultSuccessListener() {
        GameCanvasControl.OnCanvasOnEvent("Canvas Information");
        GamePanelControl.OnGamePanelOffEvent("Fire Result");
        GamePanelControl.OnGamePanelOnEvent("Fire Menu");
    }

    private void FireResultFailListener() {
        GameCanvasControl.OnCanvasChangeEvent("Canvas Outside");
        GameCanvasControl.OnCanvasOnEvent("Canvas Information");
    }
}