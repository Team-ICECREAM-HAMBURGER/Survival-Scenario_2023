using System;
using System.Text;
using TMPro;
using UnityEngine;

public class PlayerBehaviourShelter : MonoBehaviour, IPlayerBehaviour {
    [SerializeField] private GameObject shelterResultPanel;
    [SerializeField] private TMP_Text shelterResultTitle;
    [SerializeField] private TMP_Text shelterResultContent;

    [Space(10f)]

    [SerializeField] private GameObject shelterLoadingPanel;
    [SerializeField] private TMP_Text shelterLoadingTitle;

    private int spendTime;

    
    public void Init() {
        this.spendTime = 2;
    }

    public void Behaviour() {
        if (!World.Instance.HasShelter) {
            World.Instance.HasShelter = true;
            PanelUpdate();
            
            Player.Instance.StatusEffectInvoke(this.spendTime);
            World.Instance.TimeUpdate(this.spendTime);
            
            GameInformationManager.OnGameDataSaveEvent();
        }

        WorldInformation.OnCurrentTimeDayUpdate.Invoke(World.Instance.TimeDay);
        WorldInformation.OnCurrentLocationUpdate.Invoke("휴식처");
    }

    private void PanelUpdate() {
        var title = String.Empty;
        var content = new StringBuilder();
        
        title = "작업 완료";
        content.Clear();

        content.Append("- 결과\n");
        content.Append("휴식처를 설치하였다.\n");
        content.Append("이제 좀 더 편안한 생활을 즐길 수 있다.\n");

        this.shelterLoadingTitle.text = "휴식처를 설치하는 중...";
        this.shelterResultTitle.text = title;
        this.shelterResultContent.text = content.ToString();
        
        this.shelterLoadingPanel.SetActive(true);
        this.shelterResultPanel.SetActive(true);
    }
}