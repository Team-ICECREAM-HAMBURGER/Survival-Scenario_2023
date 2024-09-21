using System.Text;
using TMPro;
using UnityEngine;

public class PlayerBehaviourRest : PlayerBehaviour {
    [Header("Behaviour Result Panel")]
    [SerializeField] private GameObject restResultPanel;
    [SerializeField] private TMP_Text restResultTitle;
    [SerializeField] private TMP_Text restResultContent;
    
    [Space(25f)]
    
    [Header("Behaviour Loading Panel")]
    [SerializeField] private GameObject restLoadingPanel;
    [SerializeField] private TMP_Text restLoadingTitle;

    private string restResultTitleText;
    private StringBuilder restResultContentText;
    
    
    public override void Init() {
        // this.behaviourSpendTime = 125;
        this.restResultContentText = new();
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
        
            // Panel Update
            this.restResultTitleText = "휴식을 취했다.";
            this.restResultContentText.Clear();

            this.restResultContentText.Append("- 결과\n");
            this.restResultContentText.Append("모닥불의 온기에 몸을 녹이며 휴식을 취했다.\n");
            this.restResultContentText.Append("꽤 시간이 흘렀다. 얼추 체력을 회복했으니 다시 움직여보자.\n");
            
            PanelUpdate(true);
        }
        else {
            this.restResultTitleText = "모닥불이 없다.";
            this.restResultContentText.Clear();

            this.restResultContentText.Append("- 결과\n");
            this.restResultContentText.Append("화려한 온기로 우리를 감싸줄 모닥불이 없다.\n");
            this.restResultContentText.Append("지금 상태로는 휴식을 취할 수 없다.\n");
            this.restResultContentText.Append("일단은 불부터 피우자.\n");
            
            PanelUpdate(false);
        }
    }

    private void PanelUpdate(bool value) {
        if (value) {
            this.restLoadingTitle.text = "휴식을 취하는 중...";
            this.restResultTitle.text = this.restResultTitleText;
            this.restResultContent.text = this.restResultContentText.ToString();
        }
        else {
            this.restResultTitle.text = this.restResultTitleText;
            this.restResultContent.text = this.restResultContentText.ToString();
        }
        
        this.restLoadingPanel.SetActive(value);
        this.restResultPanel.SetActive(true);
    }
}