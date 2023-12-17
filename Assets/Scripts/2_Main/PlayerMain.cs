using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerMain : MonoBehaviour {
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
            GameCanvasControl.OnCanvasChangeEvent("Canvas Move");
        }
    }

    private bool CanMove() {
        // 이동하기 조건
        /*
         * 모든 스테이터스가 25% 이상.
         * 부상을 입지 않음.
        */
        
        return Player.Instance.StatusCheck(25f) && !Player.Instance.CurrentStatusEffect.ContainsKey(statusEffectType.INJURED);
    }
    
    private void Search() {
        if (CanSearch()) {
            PlayerSearch.OnSearchEvent();
        }
    }

    private bool CanSearch() {
        // 탐색하기 조건
        /*
         * 체력 20% 이상, 체온 10% 이상, 수분 10% 이상 허기 10% 이상.
         * 밤일 경우, '횃불' 아이템 1개 이상.
        */

        if (!Player.Instance.StatusCheck(20f, 10f, 10f, 10f)) {
            return false;
        }

        if (GameInfo.Instance.CurrentDayNight == dayNightType.DAY) {
            return true;
        }
        
        return Player.Instance.Inventory[itemType.TORCH].Count >= 1;
    }

    private void Fire() {
        if (CanFire()) {
            GameCanvasControl.OnCanvasChangeEvent("Canvas Fire");
            GameCanvasControl.OnCanvasOnEvent("Canvas Info");
        }
    }

    private bool CanFire() {
        // 불 피우기 조건
        /*
         * 점화 도구 1개, 불쏘시개 3개, 나무 1개 이상.
         * 날씨 맑음: 성공 확률 70%, 날씨 비: 성공 확률 30%, 날씨 눈: 성공 확률 30%
         * 성공 여부와 상관 없이 재료 소비.
        */

        if (GameInfo.Instance.IsFireInstalled) {
            return false;
        }

        if (!(Player.Instance.Inventory[itemType.FIRE_TOOL].Count >= 1) &&
            !(Player.Instance.Inventory[itemType.KINDLING].Count >= 3) &&
            !(Player.Instance.Inventory[itemType.WOOD].Count >= 1)) {
            return false;
        }

        switch (GameInfo.Instance.CurrentWeather) {
            case weatherType.SUNNY :
                return Random.Range(0, 10) > 3; // 70%

            case weatherType.RAIN :
                return Random.Range(0, 10) > 7; // 30%

            case weatherType.SNOW :
                return Random.Range(0, 10) > 7; // 30%

            default:
                return true;
        }
    }
    
    // Constructions
    private void Shelter() {
        GameCanvasControl.OnCanvasChangeEvent("Canvas Shelter");
        GameCanvasControl.OnCanvasOnEvent("Canvas Info");
    }

    private void RainGutter() {
        GameCanvasControl.OnCanvasChangeEvent("Canvas RainGutter");
        GameCanvasControl.OnCanvasOnEvent("Canvas Info");
    }
}