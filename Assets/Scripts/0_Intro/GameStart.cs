using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameStart : MonoBehaviour {
    private Button _button;
    
    
    private void Init() {
        this._button = this.gameObject.GetComponent<Button>();
        this._button.onClick.AddListener(() => {
            // Game Loading...
            SceneManager.LoadScene("LoadingScene");
        
            // Has Previous Save Data?
            if (gameManager.instance.GameFileCheck()) {  // True -> Load data
                gameManager.instance.GameFileLoad();
            }
            else {  // False -> Create Data + Load Data
                gameManager.instance.GameFileCreate();
                gameManager.instance.GameFileLoad();
            }
        });
    }

    private void Awake() {
        Init();
    }
}