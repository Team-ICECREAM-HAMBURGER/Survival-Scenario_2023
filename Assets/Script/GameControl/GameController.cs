using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameController Instance;
    
    private void Init() {
        if (Instance != null) {
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        
        GameOptionLoad();
    }

    private void Awake() {
        Init();
    }

    public void GameFileSave() {
        
    }

    public void GameFileLoad() {
        
    }

    public void GameFileCreate() {
        
    }

    public bool GameFileCheck() {
        return true;
    }
    
    public void GameOptionSave() {
        
    }

    public void GameOptionLoad() {
        
    }

    private void GameSessionInfo() {
        
    }
}