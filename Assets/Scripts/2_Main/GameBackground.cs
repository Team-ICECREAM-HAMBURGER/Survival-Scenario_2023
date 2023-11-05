using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBackground : MonoBehaviour {
    public static GameBackground Instance;
    
    [SerializeField] private GameObject[] backgrounds;


    private void Init() {
        if (Instance != null) {
            return;
        }

        Instance = this;
    }
    
    private void Awake() {
        Init();
    }

    public void BackgroundChange(string backgroundName) {
        foreach (var VARIABLE in this.backgrounds) {
            if (VARIABLE.name == backgroundName) {
                VARIABLE.SetActive(true);
                continue;
            }
            
            VARIABLE.SetActive(false);
        }
    }
}
