using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameControlPanel : MonoBehaviour {
    [SerializeField] private List<GameObject> panelList;

    public delegate void GamePanelUpdateHandler(GameObject obj);
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

    private void GamePanelChange(GameObject obj) {
        // foreach (var variable in this.panelList) {
        //     if (variable.name == objectName) {
        //         variable.SetActive(true);
        //         continue;
        //     }
        //     
        //     variable.SetActive(false);
        // }
    }

    private void GamePanelOn(GameObject obj) {
        // foreach (var variable in this.panelList.Where(variable => variable.name == objectName)) {
        //     variable.SetActive(true);
        // }
    }
    
    private void GamePanelOff(GameObject obj) {
        // foreach (var variable in this.panelList.Where(variable => variable.name == objectName)) {
        //     variable.SetActive(false);
        // }
    }
}