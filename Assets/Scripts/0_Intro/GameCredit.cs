using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCredit : MonoBehaviour {
    private Button _button;


    private void Init() {
        this._button = this.gameObject.GetComponent<Button>();
        this._button.onClick.AddListener(() => {
            
        });
    }

    private void Awake() {
        Init();
    }
}