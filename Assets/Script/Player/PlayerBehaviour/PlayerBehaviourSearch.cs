using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerBehaviourSearch : MonoBehaviour, IPlayerBehaviour {   // Presenter
    [SerializeField] private float[] requireStatusValues = new float[4];
    
    [SerializeField] private Canvas canvasSearch;
    [SerializeField] private Canvas canvasOutside;
    [SerializeField] private Canvas canvasInformation;
    
    [Space(10f)]
    
    [SerializeField] private GameObject searchResult;
    [SerializeField] private TMP_Text searchResultTitle;
    [SerializeField] private TMP_Text searchResultContent;
    
    [Space(10f)]
    
    [SerializeField] private GameObject searchLoading;
    
    public delegate void SearchEventUpdateViewHandler(string value1, string value2);
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
        if (!BehaviourCheck()) {
            return;
        }
        
        // Player Status Update
        // Player.Instance.StatusUpdate(this.requireStatusValues);
        
        // Random Event; Search
        GameRandomEventSearch.OnSearchRandomEvent();
        
        // Time Update
        TimeManager.Instance.WorldTimeUpdate(15);
    }
    
    private void UpdateView(string title, string content) {
        this.searchResultTitle.text = title;
        this.searchResultContent.text = content;
        
        this.canvasSearch.enabled = true;
        
        this.canvasOutside.enabled = false;
        this.canvasInformation.enabled = false;
        
        this.searchLoading.SetActive(true);
        this.searchResult.SetActive(true);
    }

    public void ResetView() {
        this.searchResultTitle.text = String.Empty;
        this.searchResultContent.text = String.Empty;
        
        this.canvasSearch.enabled = false;
        
        this.canvasOutside.enabled = true;
        this.canvasInformation.enabled = true;
        
        this.searchLoading.SetActive(false);
        this.searchResult.SetActive(false);
    }
}