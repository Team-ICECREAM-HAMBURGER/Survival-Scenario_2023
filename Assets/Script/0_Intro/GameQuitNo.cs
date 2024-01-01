using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameQuitNo : gameQuit {
    private void Init() {
        base.noButton = this.gameObject.GetComponent<Button>();
        base.noButton.onClick.AddListener(base.QuitNo);
    }

    private void Awake() {
        Init();
    }
}