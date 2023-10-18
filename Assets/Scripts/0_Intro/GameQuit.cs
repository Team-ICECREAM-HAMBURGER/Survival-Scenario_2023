using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameQuit : MonoBehaviour {
    [SerializeField] protected GameObject canvasQuit;
    private Button _quitButton;
    protected Button NoButton;
    protected Button YesButton;
    
    
    private void Init() {
        this.canvasQuit.SetActive(false);
        
        this._quitButton = this.gameObject.GetComponent<Button>();
        this._quitButton.onClick.AddListener(() => {
            this.canvasQuit.SetActive(true);
        });
    }
    
    private void Awake() {
        Init();
    }

    protected void QuitYes() {
        Application.Quit();
    }

    protected void QuitNo() {
        this.canvasQuit.SetActive(false);
    }
}