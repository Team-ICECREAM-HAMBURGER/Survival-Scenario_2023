using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameWarningView : MonoBehaviour {
    [SerializeField] private Button okButton;
    [Space(10f)]
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text contentText;

    public delegate void WarningMessageHandler(string title, string content);  // TODO: string, string
    public static WarningMessageHandler OnWarningMessageEvent;
    

    private void Init() {
        this.okButton.onClick.AddListener(ReturnToMain);
        OnWarningMessageEvent += WarningEvent;
    }

    private void Awake() {
        Init();
    }

    private void WarningEvent(string title, string content) {
        this.titleText.text = title;
        this.contentText.text = content;
        
        GameCanvasControl.OnCanvasOnEvent("Canvas Warning");
    }
    
    private void ReturnToMain() {
        GameCanvasControl.OnCanvasChangeEvent("Canvas Main");
        GameCanvasControl.OnCanvasOnEvent("Canvas Background");
        GameCanvasControl.OnCanvasOnEvent("Canvas Info");
    }
}