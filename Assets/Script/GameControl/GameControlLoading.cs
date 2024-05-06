using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameControlLoading : MonoBehaviour {
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
        var elapsedTime = 0f;
        var duration = 2f; // 로딩이 완료되는 데 걸리는 시간

        while (elapsedTime < duration) {
            elapsedTime += Time.deltaTime;
            this.indicator.value = Mathf.Lerp(0, 1, elapsedTime / duration);
            
            yield return null;
        }

        this.indicator.value = 0;
        this.gameObject.SetActive(false);
    }
}
