using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class newGame : MonoBehaviour {
    private Button _button;
    
    
    private void Init() {
        this._button = this.gameObject.GetComponent<Button>();
        this._button.onClick.AddListener(() => {
            // Has Save File?
            if (gameManager.instance.GameFileCheck()) {
                // Warn -> T or F -> Create or Return
            }
            else {
                gameManager.instance.GameFileCreate();
                gameManager.instance.GameFileLoad();
            }
        
            // Game Loading...
            SceneManager.LoadScene("LoadingScene");
        });
    }

    private void Awake() {
        Init();
    }
}