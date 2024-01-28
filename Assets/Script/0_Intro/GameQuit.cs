using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameQuit : MonoBehaviour {
    [SerializeField] protected GameObject canvasQuit;
    private Button quitButton;
    protected Button NoButton;
    protected Button YesButton;
    
    
    private void Init() {
        this.canvasQuit.SetActive(false);
        
        this.quitButton = this.gameObject.GetComponent<Button>();
        this.quitButton.onClick.AddListener(() => {
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