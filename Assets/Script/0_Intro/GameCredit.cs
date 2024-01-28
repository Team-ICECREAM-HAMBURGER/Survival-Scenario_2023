using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCredit : MonoBehaviour {
    private Button button;


    private void Init() {
        this.button = this.gameObject.GetComponent<Button>();
        this.button.onClick.AddListener(() => {
            
        });
    }

    private void Awake() {
        Init();
    }
}