using System.Text;
using TMPro;
using UnityEngine;

public class PlayerBehaviourSleep : PlayerBehaviour {
    [Header("Behaviour Result Panel")]
    [SerializeField] private GameObject sleepResultPanel;
    [SerializeField] private TMP_Text sleepResultTitle;
    [SerializeField] private TMP_Text sleepResultContent;
    
    [Space(25f)]
    
    [Header("Behaviour Loading Panel")]
    [SerializeField] private GameObject sleepLoadingPanel;
    [SerializeField] private TMP_Text sleepLoadingTitle;

    private string sleepResultTitleText;
    private StringBuilder sleepResultContentText;
    
    
    public override void Init() {
        this.sleepResultContentText = new();
    }

    private bool CanBehaviour() {
        return World.Instance.HasFire;
    }
    
    public override void Behaviour() {
        if (CanBehaviour()) {
            // Player Status Update
            OnPlayerStatusUpdate.Invoke();
            
            // Player Status Effect Update
            PlayerBehaviourManager.Instance.StatusEffectInvoke(this.behaviourSpendTime);
            
            // World Weather Update
            // TODO
            
            // World Info. Update
            PlayerBehaviourManager.Instance.WorldTimeUpdate(this.behaviourSpendTime);
            
            // Game Data Update
            PlayerBehaviourManager.Instance.GameDataSaveInvoke();
            
            // Panel
            this.sleepResultTitleText = "눈을 붙였다.";
            this.sleepResultContentText.Clear();

            this.sleepResultContentText.Append("- 결과\n");
            this.sleepResultContentText.Append("모닥불의 온기에 몸을 녹이며 잠시 눈을 붙였다.\n");
            this.sleepResultContentText.Append("하루가 꼬박 흘렀다. 힘쎄고 강한 아침이 나를 반긴다.\n");
            
            PanelUpdate(true);
        }        
        else {
            this.sleepResultTitleText = "모닥불이 없다.";
            this.sleepResultContentText.Clear();

            this.sleepResultContentText.Append("- 결과\n");
            this.sleepResultContentText.Append("화려한 온기로 우리를 감싸줄 모닥불이 없다.\n");
            this.sleepResultContentText.Append("지금 상태로는 자다가 얼어 죽는다.\n");
            this.sleepResultContentText.Append("일단은 불부터 피우자.\n");
            
            PanelUpdate(false);
        }
    }

    private void PanelUpdate(bool value) {
        if (value) {
            this.sleepLoadingTitle.text = "잠을 청하는 중...";
            this.sleepResultTitle.text = this.sleepResultTitleText;
            this.sleepResultContent.text = this.sleepResultContentText.ToString();
        }
        else {
            this.sleepResultTitle.text = this.sleepResultTitleText;
            this.sleepResultContent.text = this.sleepResultContentText.ToString();
        }
        
        this.sleepLoadingPanel.SetActive(value);
        this.sleepResultPanel.SetActive(true);
    }
}