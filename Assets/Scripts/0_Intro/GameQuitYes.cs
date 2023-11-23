using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameQuitYes : gameQuit {
    private void Init() {
        base.yesButton = this.gameObject.GetComponent<Button>();
        base.yesButton.onClick.AddListener(base.QuitYes);
    }

    private void Awake() {
        Init();
    }
}