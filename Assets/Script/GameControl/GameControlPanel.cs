using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameControlPanel : MonoBehaviour {
    [SerializeField] private List<GameObject> panelList;

    public delegate void GamePanelUpdateHandler(string value);
    public static GamePanelUpdateHandler OnGamePanelChangeEvent;
    public static GamePanelUpdateHandler OnGamePanelOnEvent;
    public static GamePanelUpdateHandler OnGamePanelOffEvent;

    
    private void Init() {
        OnGamePanelChangeEvent += GamePanelChange;
        OnGamePanelOnEvent += GamePanelOn;
        OnGamePanelOffEvent += GamePanelOff;
        
        foreach (var variable in GameObject.FindGameObjectsWithTag("Panel")) {
            this.panelList.Add(variable);
        }
    }
    
    private void Awake() {
        Init();
    }

    private void GamePanelChange(string objectName) {
        foreach (var variable in this.panelList) {
            if (variable.name == objectName) {
                variable.SetActive(true);
                continue;
            }
            
            variable.SetActive(false);
        }
    }

    private void GamePanelOn(string objectName) {
        foreach (var variable in this.panelList.Where(variable => variable.name == objectName)) {
            variable.SetActive(true);
        }
    }
    
    private void GamePanelOff(string objectName) {
        foreach (var variable in this.panelList.Where(variable => variable.name == objectName)) {
            variable.SetActive(false);
        }
    }
}