using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {
    [SerializeField] private GameObject moveLoadingScreen; 
    [Space(10f)]
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;
    
    
    private void Init() {
        this.moveLoadingScreen.SetActive(false);
        
        this.yesButton.onClick.AddListener(Move);
        this.noButton.onClick.AddListener(ReturnToMain);
    }

    private void Start() {
        Init();
    }

    private void Move() {
        // Loading...
        this.moveLoadingScreen.SetActive(true);
        
        // Update the Player Status Values
        Player.Instance.StatusUpdate(-25f);
        
        // Result
        // TODO : this.moveResultScreen -> Text(Title, Content) Update
    }

    private void ReturnToMain() {
        GameCanvasControl.OnCanvasChangeEvent("Canvas Outside");
        GameCanvasControl.OnCanvasOnEvent("Canvas Information");
    }
}