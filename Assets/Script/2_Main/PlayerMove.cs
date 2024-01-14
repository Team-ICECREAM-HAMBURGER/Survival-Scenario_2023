using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;
    [Space(10f)]
    [SerializeField] private GameObject movingScreen; 
    [SerializeField] private GameObject resultScreen;
    
    
    private void Init() {
        this.movingScreen.SetActive(false);
        this.resultScreen.SetActive(false);
        
        this.yesButton.onClick.AddListener(Move);
        this.noButton.onClick.AddListener(ReturnToMain);
    }

    private void Start() {
        Init();
    }

    private void Move() {
        // Loading...
        this.movingScreen.SetActive(true);
        this.resultScreen.SetActive(true);
        
        // Update the Player Status Values
        Player.Instance.StatusUpdate(-25f);
        
        // Result
        // TODO : this.resultScreen -> Text(Title, Content) Update
    }

    private void ReturnToMain() {
        GameCanvasControl.OnCanvasChangeEvent("Canvas Outside");
        GameCanvasControl.OnCanvasOnEvent("Canvas Information");
    }
}