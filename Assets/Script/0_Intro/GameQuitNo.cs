using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameQuitNo : GameQuit {
    private void Init() {
        base.NoButton = this.gameObject.GetComponent<Button>();
        base.NoButton.onClick.AddListener(base.QuitNo);
    }

    private void Awake() {
        Init();
    }
}