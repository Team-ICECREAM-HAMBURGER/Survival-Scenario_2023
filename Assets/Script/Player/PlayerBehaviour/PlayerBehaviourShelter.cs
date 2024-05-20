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
    
    
    public void Behaviour() {
        if (!World.Instance.IsShelterSet) {
            World.Instance.ShelterUpdate(true);
            PanelUpdate();
            
            World.Instance.WorldTimeUpdate(2);
        }
    }

    private void PanelUpdate() {
        var title = String.Empty;
        var content = new StringBuilder();
        
        title = "작업 완료";
        content.Clear();

        content.Append("- 결과\n");
        content.Append("휴식처를 설치하였다.\n");
        content.Append("이제 좀 더 편안한 생활을 즐길 수 있다.\n");
        
        this.shelterResultTitle.text = title;
        this.shelterResultContent.text = content.ToString();
        
        this.shelterLoadingPanel.SetActive(true);
        this.shelterResultPanel.SetActive(true);
    }
}