using System;
using UnityEngine;
using UnityEngine.Events;

public class GameControlCanvas : MonoBehaviour {
    public static UnityEvent<Canvas, bool> OnCanvasUpdate;


    private void Init() {
        OnCanvasUpdate = new();
        OnCanvasUpdate.AddListener(CanvasUpdate);
    }

    private void Awake() {
        Init();
    }

    private void CanvasUpdate(Canvas target, bool value) {
        target.enabled = value;
    }
    
    public void OnCanvasActive(Canvas target) {
        target.enabled = true;
    }
    
    public void OnCanvasDeActive(Canvas target) {
        target.enabled = false;
    }
}