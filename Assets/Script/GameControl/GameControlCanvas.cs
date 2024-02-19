using System.Collections.Generic;
using UnityEngine;

public class GameControlCanvas : MonoBehaviour {
    public delegate void CanvasUpdateHandler(Canvas obj);
    public static CanvasUpdateHandler OnCanvasChangeEvent;
    public static CanvasUpdateHandler OnCanvasOnEvent;
    public static CanvasUpdateHandler OnCanvasOffEvent;
    

    private void Init() {
        OnCanvasChangeEvent += CanvasChange;
        OnCanvasOnEvent += CanvasOn;
        OnCanvasOffEvent += CanvasOff;
    }

    private void Awake() {
        Init();
    }
    
    private void CanvasChange(Canvas obj) {
        // foreach (var variable in this.canvasList) {
        //     variable.enabled = false || variable.name == canvasName;
        // }    
    }

    private void CanvasOn(Canvas obj) {
        // foreach (var variable in this.canvasList.Where(variable => variable.name == canvasName)) {
        //     variable.enabled = true;
        // }
    }

    private void CanvasOff(Canvas obj) {
        // foreach (var variable in this.canvasList.Where(variable => variable.name == canvasName)) {
        //     variable.enabled = false;
        // }
    }
}