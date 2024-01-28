using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameCanvasControl : MonoBehaviour {
    [SerializeField] private List<Canvas> canvasList;
    
    public delegate void CanvasUpdateHandler(string value);
    public static CanvasUpdateHandler OnCanvasChangeEvent;
    public static CanvasUpdateHandler OnCanvasOnEvent;
    public static CanvasUpdateHandler OnCanvasOffEvent;
    

    private void Init() {
        this.canvasList = new List<Canvas>();
        
        foreach (var variable in GameObject.FindGameObjectsWithTag("Canvas")) {
            this.canvasList.Add(variable.GetComponent<Canvas>());
        }

        OnCanvasChangeEvent += CanvasChange;
        OnCanvasOnEvent += CanvasOn;
        OnCanvasOffEvent += CanvasOff;
    }

    private void Awake() {
        Init();
    }
    
    private void CanvasChange(string canvasName) {
        foreach (var variable in this.canvasList) {
            variable.enabled = false || variable.name == canvasName;
        }    
    }

    private void CanvasOn(string canvasName) {
        foreach (var variable in this.canvasList.Where(variable => variable.name == canvasName)) {
            variable.enabled = true;
        }
    }

    private void CanvasOff(string canvasName) {
        foreach (var variable in this.canvasList.Where(variable => variable.name == canvasName)) {
            variable.enabled = false;
        }
    }
}