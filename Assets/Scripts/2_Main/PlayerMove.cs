using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMove : MonoBehaviour {
    [Header("Move")] 
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;
    [Space(10f)]
    [SerializeField] private GameObject movingGameObject;
    [SerializeField] private GameObject resultGameObject;
    
    
    private void Init() {
        this.movingGameObject.SetActive(false);
        this.resultGameObject.SetActive(false);
        
        this.yesButton.onClick.AddListener(Move);
        this.noButton.onClick.AddListener(ReturnToMain);
    }

    private void Start() {
        Init();
    }

    private void Move() {
        // Loading...
        this.movingGameObject.SetActive(true);
        this.resultGameObject.SetActive(true);
        
        // Update the Player Status Values
        player.instance.StatusUpdate(-25);
        
        // Result
        // TODO : this.resultGameObject -> Text(Title, Content) Update
    }

    private void ReturnToMain() {
        player.instance.CanvasChange("Canvas Move");
    }
}