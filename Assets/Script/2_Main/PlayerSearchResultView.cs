using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerSearchResultView : MonoBehaviour {
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text contentText;
    [SerializeField] private Button okButton;

    public delegate void SearchResultUIUpdateHandler(string value);
    public static SearchResultUIUpdateHandler OnSearchResultUIInjured;
    public static SearchResultUIUpdateHandler OnSearchResultUIFarming;
    public static SearchResultUIUpdateHandler OnSearchResultUIHunting;
    public static SearchResultUIUpdateHandler OnSearchResultUIInDanger;
    
    
    private void Init() {
        OnSearchResultUIInjured += Injured;
        OnSearchResultUIFarming += Farming;
        OnSearchResultUIHunting += Hunting;
        OnSearchResultUIInDanger += InDanger;
        
        this.titleText.text = "탐색 결과";
        
        this.okButton.onClick.AddListener(SearchingResultOk);
    }

    private void Awake() {
        Init();
    }

    private void Farming(string value) {
        this.contentText.text = value;
    }

    private void Hunting(string value) {
        this.contentText.text = value;
    }
    
    private void Injured(string value) {
        this.contentText.text = value;
    }

    private void InDanger(string value) {
        this.contentText.text = value;
    }
    
    private void SearchingResultOk() {
        // Return to Outside Screen
        GameCanvasControl.OnCanvasChangeEvent("Canvas Outside");
        GameCanvasControl.OnCanvasOnEvent("Canvas Information");
    }
}