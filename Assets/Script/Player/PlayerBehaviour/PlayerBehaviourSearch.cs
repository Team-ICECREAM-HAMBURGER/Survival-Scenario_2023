using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviourSearch : MonoBehaviour, IPlayerBehaviour {   // Presenter
    [SerializeField] private Canvas canvasSearch;
    [SerializeField] private GameObject panelSearchResult;
    [SerializeField] private GameObject panelSearchLoading;
    
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
        
        // Random Event
        IGameRandomEvent.OnPlayerBehaviourEvent();
    }
    
    public void UpdateView() {
        // View Change
        GameControlCanvas.OnCanvasChangeEvent(this.canvasSearch);
        
        // Loading Anim.
        GameControlPanel.OnGamePanelOnEvent(this.panelSearchLoading);
        
        // 
    }

    public void ResetView() {
        
    }
}