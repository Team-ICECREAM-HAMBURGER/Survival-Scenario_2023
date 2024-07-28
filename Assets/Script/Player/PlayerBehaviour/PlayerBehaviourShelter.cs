using System;
using System.Text;
using TMPro;
using UnityEngine;

public class PlayerBehaviourShelter : PlayerBehaviour {
    [Space(25f)] 
    [Header("Game Screen Update Resource")] 
    [SerializeField] private Canvas shelterCanvas;
    [SerializeField] private Canvas outsideCanvas;
    
    [Space(25f)]
    
    [Header("Behaviour Result Panel")]
    [SerializeField] private GameObject shelterResultPanel;
    [SerializeField] private TMP_Text shelterResultTitle;
    [SerializeField] private TMP_Text shelterResultContent;

    [Space(10f)]

    [Header("Behaviour Loading Panel")]
    [SerializeField] private GameObject shelterLoadingPanel;
    [SerializeField] private TMP_Text shelterLoadingTitle;

    private int makeShelterSpendTime;
    
    private string currentLocationText;
    
    private string shelterResultTitleText;
    private StringBuilder shelterResultContentText;

    
    public override void Init() {
        this.makeShelterSpendTime = 2;

        this.currentLocationText = "휴식처";
        
        this.shelterResultTitleText = String.Empty;
        this.shelterResultContentText = new();
    }

    private bool CanBehaviour() {
        return PlayerBehaviourManager.Instance.CanBehaviour(GameControlType.Behaviour.SHELTER);
    }

    public override void Behaviour() {
        if (!CanBehaviour()) {
            PlayerBehaviourManager.Instance.WorldShelterSet(true);
            
            PlayerBehaviourManager.Instance.WorldTimeUpdate(this.makeShelterSpendTime);
            
            PlayerBehaviourManager.Instance.GameDataSaveInvoke();
            
            PanelUpdate();
        }
        
        PanelUpdateCanvasSet();

        PlayerBehaviourManager.Instance.WorldCurrentLocationUpdate(this.currentLocationText);
    }

    private void PanelUpdate() {
        // RESET
        this.shelterResultTitleText = String.Empty;
        this.shelterResultContentText.Clear();
        
        this.shelterResultTitleText = "작업 완료";
        this.shelterResultContentText.Clear();

        this.shelterResultContentText.Append("- 결과\n");
        this.shelterResultContentText.Append("휴식처를 설치하였다.\n");
        this.shelterResultContentText.Append("이제 좀 더 편안한 생활을 즐길 수 있다.\n");

        this.shelterLoadingTitle.text = "휴식처를 설치하는 중...";
        this.shelterResultTitle.text = this.shelterResultTitleText;
        this.shelterResultContent.text = this.shelterResultContentText.ToString();
        
        this.shelterLoadingPanel.SetActive(true);
        this.shelterResultPanel.SetActive(true);
        
    }

    private void PanelUpdateCanvasSet() {
        this.shelterCanvas.enabled = true;
        this.outsideCanvas.enabled = false;
    }
}