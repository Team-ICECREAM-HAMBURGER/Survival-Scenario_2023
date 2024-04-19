using System;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour {
    // TODO: 스테이터스 이펙트 초기화 -> 리스트에 이펙트 넣어서 호출
    
    public delegate void StatusEffectEventHandler();
    public static StatusEffectEventHandler OnInjuredEffectEvent;
    
    
    private void Init() {

    }

    private void Awake() {
        Init();
    }
    
    
}