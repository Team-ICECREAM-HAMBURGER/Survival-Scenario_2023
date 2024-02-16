using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviourMoveView : MonoBehaviour {
    [Header("Loading")]
    [SerializeField] private GameObject moveLoadingScreen;

    [Space(10f)]
    
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text contentText;
    
    [Space(10f)]
    
    [Header("Behaviour Warning")]
    [SerializeField] private GameObject moveWarningScreen;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;

    [Space(10f)]
    
    [Header("Behaviour Result")]
    [SerializeField] private GameObject moveResultScreen;
    [SerializeField] private Button okButton;
    
    public delegate void OnResultMessageUpdateHandler(string title, string content);
    public static OnResultMessageUpdateHandler OnMessageResultEvent;
    public static OnResultMessageUpdateHandler OnMessageWarningEvent;

    
    private void Init() {
        OnMessageResultEvent += MessageResult;
        OnMessageWarningEvent += MessageWarning;
        
        this.yesButton.onClick.AddListener(Moving);
        this.noButton.onClick.AddListener(ReturnToMain);
        this.okButton.onClick.AddListener(ReturnToMain);
    }

    private void Awake() {
        Init();
    }

    private void MessageResult(string title, string content) {
        this.moveResultScreen.SetActive(true);
        
        this.titleText.text = title;
        this.contentText.text = content;
    }

    private void MessageWarning(string title, string content) {
        this.moveWarningScreen.SetActive(true);

        this.titleText.text = title;
        this.contentText.text = content;
    }

    private void Moving() {
        this.moveLoadingScreen.SetActive(true);
    }

    private void ReturnToMain() {
        GameControlCanvas.OnCanvasChangeEvent("Canvas Outside");
        GameControlCanvas.OnCanvasOnEvent("Canvas Information");
    }
}