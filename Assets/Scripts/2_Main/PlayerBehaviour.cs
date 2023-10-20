using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Behaviour {
    MOVE,
    SEARCH,
    REST,
    SLEEP,
    CRAFT,
    INVENTORY,
    COOK
}

public enum CanvasLayer {
    PAUSE,  // 0
    CRAFTING,
    INVENTORY,
    REST,
    SLEEP,  
    SHELTER,    // 5
    FIRE,
    SEARCH,
    INFO,
    MOVE,
    MAIN    // 10
}

public class PlayerBehaviour : MonoBehaviour {
    private int _searchCounter = 1;

    private List<Canvas> _canvasArray = new List<Canvas>();
    
    [Header("Main")]
    [SerializeField] private Button moveButton;
    [SerializeField] private Button searchButton;
    [SerializeField] private Button fireButton;
    [SerializeField] private Button shelterButton;
    [SerializeField] private Button rainGutter;

    
    private void Init() {
        foreach (var obj in GameObject.FindGameObjectsWithTag("Canvas")) {
            this._canvasArray.Add(obj.GetComponent<Canvas>());
        }

        foreach (var VARIABLE in this._canvasArray) {
            Debug.Log(VARIABLE);
        }
        
        this.moveButton.onClick.AddListener(Move);
    }

    private void Awake() {
        Init();
    }

    private void Move() {
        if (this._searchCounter >= 1) {
            if (Player.Instance.CanBehaviour(Behaviour.MOVE)) {
                // Change Canvas
                foreach (var VARIABLE in this._canvasArray) {
                    VARIABLE.enabled = false;
                }
                
                this._canvasArray[(int)CanvasLayer.MOVE].enabled = true;
                
                // MOVE ANI. Screen
                
                // Status Update
                Player.Instance.PlayerStatus.Stamina -= 25;
                Player.Instance.PlayerStatus.BodyHeat -= 25;
                Player.Instance.PlayerStatus.Calories -= 25;
                Player.Instance.PlayerStatus.Hydration -= 25;

                // RESULT

            }
            else {
                // ERROR
            }
        }
    }
}