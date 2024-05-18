using System;
using System.Text;
using TMPro;
using UnityEngine;

public class PlayerBehaviourRainGutter : MonoBehaviour, IPlayerBehaviour {
    [SerializeField] private GameObject rainGutterResultPanel;
    [SerializeField] private GameObject rainGutterLoadingPanel;
    
    [Space(10f)] 
    
    [SerializeField] private TMP_Text rainGutterResultTitle;
    [SerializeField] private TMP_Text rainGutterResultContent;
    
    
    public void Behaviour() {
        var num = 1;
        
        // 빗물 받이 설치 검사
        if (Player.Instance.Inventory.ContainsKey(GameControlType.Item.RAIN_GUTTER)) {
            Player.Instance.InventoryUpdate(GameControlType.Item.RAIN_GUTTER, -num);
            PanelUpdate(num, true);
        }
        else {
            PanelUpdate(num, false);
        }
        
        TimeManager.Instance.WorldTimeUpdate(0);
    }

    private void PanelUpdate(int num, bool canCreate) {
        var title = String.Empty;
        var content = new StringBuilder();
        
        if (canCreate) {
            title = "작업 완료";
            content.Clear();

            content.Append("- 결과\n");
            content.Append("빗물 받이를 설치하였다.\n");
            content.Append("이제 비가 오면 식수를 얻을 수 있다.\n");
            
            content.Append("\n");

            content.Append("- 사용된 아이템\n");
            content.Append(ItemManager.Instance.Items[GameControlType.Item.RAIN_GUTTER].Name);
            content.Append(" ");
            content.Append(num);
            content.Append("개\n");
        }
        else {
            title = "재료가 부족함";
            content.Clear();

            content.Append("- 결과\n");
            content.Append("설치할 수 있는 빗물 받이가 없다.\n");
            content.Append("재료를 모아 빗물 받이를 먼저 만들어보자.\n");
        }

        this.rainGutterResultTitle.text = title;
        this.rainGutterResultContent.text = content.ToString();
        
        this.rainGutterLoadingPanel.SetActive(canCreate);
        this.rainGutterResultPanel.SetActive(true);
    }

    public void PanelReset() {
        this.rainGutterResultTitle.text = String.Empty;
        this.rainGutterResultContent.text = String.Empty;
        
        this.rainGutterLoadingPanel.SetActive(false);
        this.rainGutterResultPanel.SetActive(false);
    }
}