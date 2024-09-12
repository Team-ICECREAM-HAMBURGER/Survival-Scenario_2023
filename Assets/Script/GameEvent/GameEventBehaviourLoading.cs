using System;
using TMPro;
using UnityEngine;

public class GameEventBehaviourLoading : MonoBehaviour {
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private TMP_Text resultTitle;
    [SerializeField] private TMP_Text resultContent;

    [Space(10f)] 
    
    [SerializeField] private GameObject loadingPanel;
    [SerializeField] private TMP_Text loadingTitle;
    
    
    public void BehaviourLoading() {
        this.loadingTitle.text = String.Empty;
        
        this.resultTitle.text = String.Empty;
        this.resultContent.text = String.Empty;
        
        this.loadingPanel.SetActive(false);
        this.resultPanel.SetActive(false);
    }
}