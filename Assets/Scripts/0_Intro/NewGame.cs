using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGame : MonoBehaviour {
    private Button _button;
    
    
    private void Init() {
        this._button = this.gameObject.GetComponent<Button>();
        this._button.onClick.AddListener(() => {
            // Has Save File?
            if (GameManager.Instance.GameFileCheck()) {
                // Warn -> T or F -> Create or Return
            }
            else {
                GameManager.Instance.GameFileCreate();
                GameManager.Instance.GameFileLoad();
            }
        
            // Game Loading...
            SceneManager.LoadScene("LoadingScene");
        });
    }

    private void Awake() {
        Init();
    }
}