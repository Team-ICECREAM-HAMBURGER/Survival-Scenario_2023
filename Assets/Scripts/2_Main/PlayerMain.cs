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
        if (GameInfo.instance.CurrentDayNight == dayNightType.DAY) {
            gameBackground.instance.BackgroundChange("Background Day");
        } 
        else if (GameInfo.instance.CurrentDayNight == dayNightType.NIGHT) {
            gameBackground.instance.BackgroundChange("Background Night");
        }
    }

    private void Start() {
        Init();
    }

    private void Move() {
        if (CanMove()) {
            // TODO : Player.Instance.PlayerMove.Init();
            Player.instance.CanvasChange("Canvas Move");
        }
    }

    private bool CanMove() {
        // Movable Conditions; All of Status over 25%, Search at least once more, Not injured.
        if (Player.instance.Status[statusType.STAMINA] > 25 && Player.instance.Status[statusType.BODY_HEAT] > 25 &&
            Player.instance.Status[statusType.CALORIES] > 25 && Player.instance.Status[statusType.HYDRATION] > 25) {    // Status OK
            if (GameInfo.instance.IsSearched) {  // Searched
                if (!Player.instance.StatusEffect.ContainsKey(statusEffectType.INJURED)) {   // Not Injured
                    return true;
                }
            }
        }
        
        return false;
    }
    
    private void Search() {
        // Debug
        Debug.Log("STAMINA: " + Player.instance.Status[statusType.STAMINA] + 
                  ", BODY_HEAT: " + Player.instance.Status[statusType.BODY_HEAT] +
                  ", CALORIES: " + Player.instance.Status[statusType.CALORIES] +
                  ", HYDRATION: " + Player.instance.Status[statusType.HYDRATION]);
        
        if (CanSearch()) {
            Player.instance.PlayerSearch.Init();
        }
        
        // Debug
        Debug.Log("STAMINA: " + Player.instance.Status[statusType.STAMINA] + 
                  ", BODY_HEAT: " + Player.instance.Status[statusType.BODY_HEAT] +
                  ", CALORIES: " + Player.instance.Status[statusType.CALORIES] +
                  ", HYDRATION: " + Player.instance.Status[statusType.HYDRATION]);
    }

    private bool CanSearch() {
        // Search Conditions; All of Status over 10%, Not injured, (Night) Need a 'Torch' item.
        if (Player.instance.Status[statusType.STAMINA] > 10 && Player.instance.Status[statusType.BODY_HEAT] > 10 &&
            Player.instance.Status[statusType.CALORIES] > 10 && Player.instance.Status[statusType.HYDRATION] > 10) {    // Status OK
            if (GameInfo.instance.CurrentDayNight == dayNightType.NIGHT) {  // Night
                if (Player.instance.inventory[itemType.TORCH].Count >= 1) {    // Torch OK
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
            Player.instance.CanvasChange("Canvas Fire");
            Player.instance.CanvasOn("Canvas Info");
        }
    }

    private bool CanFire() {
        if (!GameInfo.instance.IsFireInstalled) {
            // Fire Conditions; 점화도구 1개, 불쏘시개 3개, 나무 1개 -> 날씨 맑음: 70%, 날씨 비: 30%, 날씨 눈: 30% 
            if (Player.instance.inventory[itemType.FIRE_TOOL].Count >= 1 && Player.instance.inventory[itemType.KINDLING].Count >= 3 && 
                Player.instance.inventory[itemType.WOOD].Count >= 1) {    // Material OK
                switch (GameInfo.instance.CurrentWeather) {
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
        Player.instance.CanvasChange("Canvas Shelter");
        Player.instance.CanvasOn("Canvas Info");
    }

    private void RainGutter() {
        // TODO : Player.Instance.PlayerRainGutter.Init();
        Player.instance.CanvasChange("Canvas RainGutter");
        Player.instance.CanvasOn("Canvas Info");
    }
}