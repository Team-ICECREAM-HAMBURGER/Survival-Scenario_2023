using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : GameController {
    protected override void Init() {
        base.Button = this.gameObject.GetComponent<Button>();
        
        base.Button.onClick.AddListener(GameStart);
    }

    private void GameStart() {
        
    }
}