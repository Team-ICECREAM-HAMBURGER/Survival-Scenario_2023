using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerMain : MonoBehaviour {
    [Header("Main")]
    [SerializeField] private Button moveButton;
    [SerializeField] private Button searchButton;
    [SerializeField] private Button fireButton;
    [SerializeField] private Button shelterButton;
    [SerializeField] private Button rainGutter;

    
    private void Init() {
        this.moveButton.onClick.AddListener(Move);
        this.searchButton.onClick.AddListener(Search);
        this.fireButton.onClick.AddListener(Fire);
        this.shelterButton.onClick.AddListener(Shelter);
        this.rainGutter.onClick.AddListener(RainGutter);
        
        // TODO: Background Change
        if (GameInfo.Instance.CurrentDayNight == dayNightType.DAY) {
            gameBackground.instance.BackgroundChange("Background Day");
        } 
        else if (GameInfo.Instance.CurrentDayNight == dayNightType.NIGHT) {
            gameBackground.instance.BackgroundChange("Background Night");
        }
    }

    private void Start() {
        Init();
    }

    private void Move() {
        if (CanMove()) {
            // TODO : Player.Instance.PlayerMove.Init();
            Player.Instance.CanvasChange("Canvas Move");
        }
    }

    private bool CanMove() {
        // Movable Conditions; All of Status over 25%, Search at least once more, Not injured.
        if (Player.Instance.StatusCheck(25f, 25f, 25f, 25f)) {    // Status OK
            if (GameInfo.Instance.IsSearched) {  // Searched
                if (!Player.Instance.StatusEffect.ContainsKey(statusEffectType.INJURED)) {   // Not Injured
                    return true;
                }
            }
        }
        
        return false;
    }
    
    private void Search() {
        // Debug
        Debug.Log("STAMINA: " + Player.Instance.Status[statusType.STAMINA] + 
                  ", BODY_HEAT: " + Player.Instance.Status[statusType.BODY_HEAT] +
                  ", CALORIES: " + Player.Instance.Status[statusType.CALORIES] +
                  ", HYDRATION: " + Player.Instance.Status[statusType.HYDRATION]);
        
        if (CanSearch()) {
            Player.Instance.PlayerSearch.Init();
        }
        
        // Debug
        Debug.Log("STAMINA: " + Player.Instance.Status[statusType.STAMINA] + 
                  ", BODY_HEAT: " + Player.Instance.Status[statusType.BODY_HEAT] +
                  ", CALORIES: " + Player.Instance.Status[statusType.CALORIES] +
                  ", HYDRATION: " + Player.Instance.Status[statusType.HYDRATION]);
    }

    private bool CanSearch() {
        // Search Conditions; All of Status over 10%, Not injured, (Night) Need a 'Torch' item.
        if (Player.Instance.StatusCheck(20f, 10f, 10f, 10f)) {    // Status OK
            if (GameInfo.Instance.CurrentDayNight == dayNightType.NIGHT) {  // Night
                if (Player.Instance.inventory[itemType.TORCH].Count >= 1) {    // Torch OK
                    return true;
                }
                
                Debug.Log("NO TORCH");
                return false;
            }

            return true;
        }
        
        Debug.Log("NOT ENOUGH STATUS");
        return false;
    }

    private void Fire() {
        if (CanFire()) {
            // TODO : Player.Instance.PlayerFire.Init();
            Player.Instance.CanvasChange("Canvas Fire");
            Player.Instance.CanvasOn("Canvas Info");
        }
    }

    private bool CanFire() {
        if (!GameInfo.Instance.IsFireInstalled) {
            // Fire Conditions; 점화도구 1개, 불쏘시개 3개, 나무 1개 -> 날씨 맑음: 70%, 날씨 비: 30%, 날씨 눈: 30% 
            if (Player.Instance.inventory[itemType.FIRE_TOOL].Count >= 1 && Player.Instance.inventory[itemType.KINDLING].Count >= 3 && 
                Player.Instance.inventory[itemType.WOOD].Count >= 1) {    // Material OK
                switch (GameInfo.Instance.CurrentWeather) {
                    case weatherType.SUNNY :
                        if (Random.Range(0, 10) > 3) {    // 70%
                            return true;
                        }

                        return false;
                
                    case weatherType.RAIN :
                        if (Random.Range(0, 10) > 7) {  // 30%
                            return true;
                        }
                    
                        return false;
                
                    case weatherType.SNOW :
                        if (Random.Range(0, 10) > 7) {  // 30%
                            return true;
                        }
                    
                        return false;
                }
            }
        }
        
        return true;
    }
    
    // Constructions
    private void Shelter() {
        // TODO : Player.Instance.PlayerShelter.Init();
        Player.Instance.CanvasChange("Canvas Shelter");
        Player.Instance.CanvasOn("Canvas Info");
    }

    private void RainGutter() {
        // TODO : Player.Instance.PlayerRainGutter.Init();
        Player.Instance.CanvasChange("Canvas RainGutter");
        Player.Instance.CanvasOn("Canvas Info");
    }
}