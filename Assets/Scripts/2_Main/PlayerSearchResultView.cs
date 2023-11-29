using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSearchResultView : MonoBehaviour {
    public static PlayerSearchResultView Instance;

    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text contentText;
    
    
    private void Init() {
        if (Instance != null) {
            return;
        }
        
        Instance = this;
    }

    private void Awake() {
        Init();
    }

    public void Farming(Dictionary<Item, int> acquiredItems) {
        
        
        
        
        
        
        this.titleText.text = "쓸만한 것들을 찾았다.";
        this.contentText.text = @"";
    }

    public void Hunting() {
        
    }

    public void InDanger() {
        
    }

    public void Injured() {
        
    }
}