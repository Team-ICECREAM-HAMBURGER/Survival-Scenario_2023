using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameActionLoading : MonoBehaviour {
    [SerializeField] private Slider indicator;
    
    
    private void Init() {
        this.indicator.value = 0;
        this.gameObject.SetActive(true);
    }
    
    private void OnEnable() {
        Init();
        StartCoroutine(Loading());
    }

    private IEnumerator Loading() {
        while (this.indicator.value < 1) {
            this.indicator.value = Mathf.Lerp(0, 1, this.indicator.value + Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        this.indicator.value = 0;
        this.gameObject.SetActive(false);
    }
}
