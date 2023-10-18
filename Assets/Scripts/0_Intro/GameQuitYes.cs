using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameQuitYes : GameQuit {
    private void Init() {
        base.YesButton = this.gameObject.GetComponent<Button>();
        base.YesButton.onClick.AddListener(base.QuitYes);
    }

    private void Awake() {
        Init();
    }
}