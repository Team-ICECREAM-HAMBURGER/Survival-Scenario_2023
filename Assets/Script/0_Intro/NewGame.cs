using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGame : MonoBehaviour {
    private Button button;
    
    
    private void Init() {
        this.button = this.gameObject.GetComponent<Button>();
        this.button.onClick.AddListener(() => {
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