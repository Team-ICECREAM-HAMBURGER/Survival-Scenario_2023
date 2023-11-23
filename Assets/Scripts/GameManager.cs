using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {
    public static gameManager instance;
    
    private void Init() {
        if (instance != null) {
            return;
        }

        instance = this;
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