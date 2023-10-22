using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMain : MonoBehaviour {
    [Header("Main")]
    [SerializeField] private Button moveButton;
    [SerializeField] private Button searchButton;
    [SerializeField] private Button fireButton;
    [SerializeField] private Button shelterButton;
    [SerializeField] private Button rainGutter;

    private int searchCounter = 1;
    
    
    private void Init() {
        this.moveButton.onClick.AddListener(Move);
        // this.searchButton.onClick.AddListener();
        // this.fireButton.onClick.AddListener();
        // this.shelterButton.onClick.AddListener();
        // this.rainGutter.onClick.AddListener();
    }

    private void Awake() {
        Init();
    }

    private void Move() {
        // Movable Conditions; Each of Status over 25%, searchCounter value must over 1, Player must not injured.
        if (Player.instance.Status[StatusType.STAMINA] > 25 && Player.instance.Status[StatusType.BODY_HEAT] > 25 &&
            Player.instance.Status[StatusType.CALORIES] > 25 && Player.instance.Status[StatusType.HYDRATION] > 25) {
            if (this.searchCounter >= 1) {
                if (!Player.instance.Effect[EffectType.INJURE]) {
                    foreach (var VARIABLE in Player.instance.CanvasList) {
                        VARIABLE.enabled = false || VARIABLE.name == "Canvas Move";
                    }
                }
            }
        }
    }
}