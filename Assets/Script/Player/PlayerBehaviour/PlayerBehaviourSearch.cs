using System;
using System.Text;
using TMPro;
using UnityEngine;

public class PlayerBehaviourSearch : MonoBehaviour, IPlayerBehaviour {   // Presenter
    [SerializeField] private Canvas canvasSearch;
    [SerializeField] private Canvas canvasOutside;
    [SerializeField] private Canvas canvasInformation;
    
    [Space(10f)]
    
    [SerializeField] private GameObject searchResult;
    [SerializeField] private TMP_Text searchResultTitle;
    [SerializeField] private TMP_Text searchResultContent;
    
    [Space(10f)]
    
    [SerializeField] private GameObject searchLoading;
    
    public delegate void SearchEventUpdateViewHandler();
    public static SearchEventUpdateViewHandler OnSearchEventUpdateView;


    private void Init() {
        OnSearchEventUpdateView += UpdateView;
    }

    private void Awake() {
        Init();
    }

    public bool BehaviourCheck() {
        return true;
    }
    
    public void Behaviour() {
        if (BehaviourCheck()) {
            return;
        }
        
        // Player Status Update
        Player.Instance.StatusUpdate(-20f, -10f, -10f, -10f);

        GameRandomEventSearch.OnSearchRandomEvent();
    }
    
    public void UpdateView() {
        
        // TODO: GameRandomEventSearch.OnSearchRandomEvent 반환 결과
        this.searchResultTitle.text = String.Empty;
        this.searchResultContent.text = String.Empty;
        
        GameControlCanvas.OnCanvasOnEvent(this.canvasSearch);
        
        GameControlCanvas.OnCanvasOffEvent(this.canvasOutside);
        GameControlCanvas.OnCanvasOffEvent(this.canvasInformation);
        
        GameControlPanel.OnGamePanelOnEvent(this.searchLoading);
        GameControlPanel.OnGamePanelOnEvent(this.searchResult);
    }

    public void ResetView() {
        GameControlCanvas.OnCanvasOffEvent(this.canvasSearch);
        
        GameControlCanvas.OnCanvasOnEvent(this.canvasOutside);
        GameControlCanvas.OnCanvasOnEvent(this.canvasInformation);

        GameControlPanel.OnGamePanelOffEvent(this.searchLoading);
        GameControlPanel.OnGamePanelOffEvent(this.searchResult);
    }
}