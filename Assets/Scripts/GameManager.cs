using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager _instance;
    
    private void Init() {
        if (_instance != null) {
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Awake() {
        Init();
    }

    public void GameFileSave() {
        
    }

    public void GameFileLoad() {
        
    }

    public void GameOptionSave() {
        
    }

    public void GameOptionLoad() {
        
    }

    public void GameSessionInfo() {
        
    }
}