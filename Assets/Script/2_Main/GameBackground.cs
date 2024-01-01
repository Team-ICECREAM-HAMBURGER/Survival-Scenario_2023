using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBackground : MonoBehaviour {
    public static GameBackground instance;
    
    [SerializeField] private GameObject[] backgrounds;


    private void Init() {
        if (instance != null) {
            return;
        }

        instance = this;
    }
    
    private void Awake() {
        Init();
    }

    public void BackgroundChange(string backgroundName) {
        foreach (var variable in this.backgrounds) {
            if (variable.name == backgroundName) {
                variable.SetActive(true);
                
                continue;
            }
            
            variable.SetActive(false);
        }
    }
}
