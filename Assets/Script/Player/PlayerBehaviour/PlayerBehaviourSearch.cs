using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBehaviourSearch : MonoBehaviour, IPlayerBehaviour {   // Presenter
    [Header("Require Status")]
    [SerializeField] private float requireStatusStamina;
    [SerializeField] private float requireStatusBodyHeat;
    [SerializeField] private float requireStatusHydration;
    [SerializeField] private float requireStatusCalories;
    
    [Space(10f)]
    
    [SerializeField] private Canvas canvasSearch;
    [SerializeField] private Canvas canvasOutside;
    [SerializeField] private Canvas canvasInformation;
    
    [Space(10f)]
    
    [SerializeField] private GameObject searchResult;
    [SerializeField] private TMP_Text searchResultTitle;
    [SerializeField] private TMP_Text searchResultContent;
    
    [Space(10f)]
    
    [SerializeField] private GameObject searchLoading;
    

    public void Behaviour() {
        // Player Status Update
        Player.Instance.StatusUpdate(this.requireStatusStamina, this.requireStatusBodyHeat, this.requireStatusHydration, this.requireStatusCalories);
        
        // Player Status Effects Invoke
        Player.Instance.StatusEffectInvoke();
        
        // Random Event; Search
        // GameEventSearch.OnSearchRandomEvent();
        
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