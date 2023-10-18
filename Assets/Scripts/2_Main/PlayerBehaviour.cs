using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {
    public static PlayerBehaviour Instance;

    [Header("Main")]
    [SerializeField] private Button moveButton;
    [SerializeField] private Button searchButton;
    [SerializeField] private Button fireButton;
    [SerializeField] private Button shelterButton;
    [SerializeField] private Button rainGutterButton;

    [Header("Move")] 
    [SerializeField] private Button planA;
    [SerializeField] private Button planB;
    [SerializeField] private Button planC;
    
    
    private void Init() {
        if (Instance != null) {
            return;
        }

        Instance = this;
        
        this.moveButton.onClick.AddListener(Move);
        this.searchButton.onClick.AddListener(Search);
        this.fireButton.onClick.AddListener(Fire);
        this.shelterButton.onClick.AddListener(Shelter);
        this.rainGutterButton.onClick.AddListener(RainGutter);
    }

    private void Awake() {
        Init();
    }

    private void Move() {
        // Move
        /*
         * if (Search() > 1) :
         *  True -> Show Move Screen 
         *  False -> Show Error Screen
         *
         * Plan A, B, C
         *  -> Button Listener
         *
         * if (Player.CanMove()) :
         *  True -> Show Moving Ani, Update Pos.
         *  False -> Show Error Screen
         */
    }

    public void Search() {
        // Search
        /*
         * if (Player.CanMove()) :
         *  True -> Use Player Status, Show Searching Ani, Event()
         *  False -> Show Error Screen
         */
    }

    public void Shelter() {
        // Shelter
        /*
         * 
         */
    }

    public void RainGutter() {
        
    }
    
    public void Rest() {
        
    }

    public void Sleep() {
        
    }

    public void Fire() {
        
    }

    public void Inventory() {
        
    }

    public void Craft() {
        
    }

    public void Build() {
        
    }
}