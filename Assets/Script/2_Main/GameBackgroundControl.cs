using System.Linq;
using UnityEngine;

public class GameBackgroundControl : MonoBehaviour {
    [SerializeField] private GameObject[] backgrounds;

    public delegate void BackgroundUpdateHandler(string value);
    public static BackgroundUpdateHandler OnBackgroundChangeEvent;
    public static BackgroundUpdateHandler OnBackgroundOnEvent;
    public static BackgroundUpdateHandler OnBackgroundOffEvent;

    
    private void Init() {
        OnBackgroundChangeEvent += BackgroundChange;
        OnBackgroundOnEvent += BackgroundOn;
        OnBackgroundOffEvent += BackgroundOff;
    }
    
    private void Awake() {
        Init();
    }

    private void BackgroundChange(string backgroundName) {
        foreach (var variable in this.backgrounds) {
            if (variable.name == backgroundName) {
                variable.SetActive(true);
                continue;
            }
            
            variable.SetActive(false);
        }
    }

    private void BackgroundOff(string backgroundName) {
        foreach (var variable in this.backgrounds.Where(variable => variable.name == backgroundName)) {
            variable.SetActive(false);
        }
    }

    private void BackgroundOn(string backgroundName) {
        foreach (var variable in this.backgrounds.Where(variable => variable.name == backgroundName)) {
            variable.SetActive(true);
        }
    }
}