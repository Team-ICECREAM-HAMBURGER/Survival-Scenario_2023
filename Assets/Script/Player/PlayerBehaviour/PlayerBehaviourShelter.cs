using System;
using System.Text;
using TMPro;
using UnityEngine;

public class PlayerBehaviourShelter : PlayerBehaviour {
    [Space(25f)]
    
    [SerializeField] private GameObject shelterResultPanel;
    [SerializeField] private TMP_Text shelterResultTitle;
    [SerializeField] private TMP_Text shelterResultContent;

    [Space(10f)]

    [SerializeField] private GameObject shelterLoadingPanel;
    [SerializeField] private TMP_Text shelterLoadingTitle;

    private int spendTime;
    private string shelterResultTitleText;
    private StringBuilder shelterResultContentText;

    
    public override void Init() {
        this.spendTime = 2;
        this.shelterResultTitleText = String.Empty;
        this.shelterResultContentText = new();
    }

    private bool CanBehaviour() {
        return World.Instance.HasShelter;
    }

    public override void Behaviour() {
        if (!CanBehaviour()) {
            World.Instance.HasShelter = true; // TODO: World -> PlayerBehaviourManager
            
            PanelUpdate();
            
            World.Instance.TimeUpdate(this.spendTime);  // TODO: World -> PlayerBehaviourManager
            GameInformationManager.OnGameDataSaveEvent();
        }
        
        GameInformationMonitorWorld.OnCurrentLocationUpdate.Invoke("휴식처");
    }

    private void PanelUpdate() {
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
}