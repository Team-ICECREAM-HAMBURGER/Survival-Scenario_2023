using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEventGameOver : MonoBehaviour {
    [SerializeField] private CanvasGroup canvasGroup;
    
    [Space(10f)]

    [Header("Bad Ending")]
    [SerializeField] private GameObject badEndingMenu;
    [SerializeField] private TMP_Text badEndingTitle;
    [SerializeField] private TMP_Text badEndingContent;
    [SerializeField] private Button badEndingReturnButton;
    
    [Space(10f)]

    [Header("Good Ending")]
    [SerializeField] private GameObject goodEndingMenu;
    [SerializeField] private TMP_Text goodEndingTitle;
    [SerializeField] private TMP_Text goodEndingContent;
    [SerializeField] private Button goodEndingReturnButton;
    
    public delegate void GameOverEventHandler(string title, string content);
    public static GameOverEventHandler OnGameOverGoodEnding;
    public static GameOverEventHandler OnGameOverBadEnding;


    private void Init() {
        this.canvasGroup.alpha = 0f;
        
        this.badEndingMenu.SetActive(false);
        this.badEndingContent.gameObject.SetActive(false);
        this.badEndingTitle.gameObject.SetActive(false);
        this.badEndingReturnButton.gameObject.SetActive(false);

        this.goodEndingMenu.SetActive(false);
        this.goodEndingContent.gameObject.SetActive(false);
        this.goodEndingTitle.gameObject.SetActive(false);
        this.goodEndingReturnButton.gameObject.SetActive(false);
        
        OnGameOverBadEnding += BadEnding;
        OnGameOverGoodEnding += GoodEnding;
    }

    private void Awake() { 
        Init();
    }
    
    private void BadEnding(string title, string content) {
        this.badEndingMenu.SetActive(true);
        this.goodEndingMenu.SetActive(false);
        
        this.badEndingTitle.text = title;
        this.badEndingContent.text = content;
        
        StartCoroutine(Ending(this.badEndingTitle, this.badEndingContent, this.badEndingReturnButton));
    }

    private void GoodEnding(string title, string content) {
        this.badEndingMenu.SetActive(false);
        this.goodEndingMenu.SetActive(true);
        
        this.goodEndingTitle.text = title;
        this.goodEndingContent.text = content;
        
        StartCoroutine(Ending(this.goodEndingTitle, this.goodEndingContent, this.goodEndingReturnButton));
    }
    
    private IEnumerator Ending(TMP_Text title, TMP_Text content, Button button) {
        var elapsedTime = 0f;   // 흐르고 있는 시간; Time.deltaTime
        var duration = 2f;      // 로딩이 완료되는 데 걸리는 시간
        
        while (elapsedTime < duration) {
            elapsedTime += Time.deltaTime;
            this.canvasGroup.alpha = Mathf.Lerp(0, 1, elapsedTime / duration);
            
            yield return null;
        }
        
        yield return new WaitForSeconds(1.5f);
        
        content.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);
        
        title.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(1.5f);

        button.gameObject.SetActive(true);
    }

    public void GameReset() {
        GameInformationManager.OnGameDataReset();
        
        SceneManager.LoadScene(0);
    }
}