using System;
using System.Text;
using TMPro;
using UnityEngine;

enum RainGutterPanelType {
    NO_CANS,
    NO_WATER,
    SUCCESS,
    PASS
}

public class PlayerBehaviourRainGutter : PlayerBehaviour {
    [Space(25f)]
    
    [Header("Behaviour Result Panel")]
    [SerializeField] private GameObject rainGutterResultPanel;
    [SerializeField] private TMP_Text rainGutterResultTitle;
    [SerializeField] private TMP_Text rainGutterResultContent;
    
    [Space(25f)] 
    
    [Header("Behaviour Loading Panel")]
    [SerializeField] private GameObject rainGutterLoadingPanel;
    [SerializeField] private TMP_Text rainGutterLoadingTitle;

    private int makeRainGutterSpendTime;
    
    private string rainGutterResultTitleText;
    private StringBuilder rainGutterResultContentText;

    
    public override void Init() {
        this.makeRainGutterSpendTime = 1;
        
        this.rainGutterResultTitleText = String.Empty;
        this.rainGutterResultContentText = new();
    }

    private bool CanBehaviour() {
        return PlayerBehaviourManager.Instance.CanBehaviour(GameControlType.Behaviour.RAIN_GUTTER);
    }
    
    public override void Behaviour() {
        if (!CanBehaviour()) {    // Hasn't Rain Gutter
            PlayerBehaviourManager.Instance.WorldRainGutterSet(true);
            
            PanelUpdate(RainGutterPanelType.PASS);
        }
        else {    // Has Rain Gutter; 
            var emptyCans = PlayerBehaviourManager.Instance.GetInventoryAmountItem(GameControlType.Item.CAN);

            if (PlayerBehaviourManager.Instance.WorldCurrentWeatherCheck(GameControlType.Weather.RAIN)) { // Weather: Rainy
                PlayerBehaviourManager.Instance.WorldRainWaterSet(true);
                
                if (emptyCans > 0) { // Has Empty Can;
                    // Get Water
                    PlayerBehaviourManager.Instance.ItemUse((GameControlType.Item.CAN, emptyCans));
                    PlayerBehaviourManager.Instance.ItemAdd((GameControlType.Item.BOTTLE_OF_WATER, emptyCans));
                    
                    // Loading
                    PanelUpdate(RainGutterPanelType.SUCCESS);
                }
                else {  // No Empty Can;
                    // ERROR; NO_CANS
                    PanelUpdate(RainGutterPanelType.NO_CANS);
                }
            }
            else {
                if (PlayerBehaviourManager.Instance.WorldRainWaterGet()) { // Water Left
                    if (emptyCans > 0) {  // Has Empty Can
                        // Get Water
                        PlayerBehaviourManager.Instance.ItemUse((GameControlType.Item.CAN, emptyCans));
                        PlayerBehaviourManager.Instance.ItemAdd((GameControlType.Item.BOTTLE_OF_WATER, emptyCans));
                        
                        // Loading
                        PanelUpdate(RainGutterPanelType.SUCCESS);
                    }
                    else {
                        // ERROR; NO_CANS
                        PanelUpdate(RainGutterPanelType.NO_CANS);
                    }
                    
                    PlayerBehaviourManager.Instance.WorldRainWaterSet(false);
                }
                else {
                    // ERROR; NO_WATER
                    PanelUpdate(RainGutterPanelType.NO_WATER);
                }
            }
        }
        
        // World Info. Update
        PlayerBehaviourManager.Instance.WorldTimeUpdate(this.makeRainGutterSpendTime);
        
        // Game Data Save
        PlayerBehaviourManager.Instance.GameDataSaveInvoke();
    }

    private void PanelUpdate(RainGutterPanelType type) {
        var needLoading = false;

        this.rainGutterResultTitleText = String.Empty;
        this.rainGutterResultContentText.Clear();
        
        switch (type) {
            case RainGutterPanelType.PASS :
                needLoading = true;
                
                this.rainGutterResultTitleText = "작업 완료";
                this.rainGutterResultContentText.Clear();

                this.rainGutterResultContentText.Append("- 결과\n");
                this.rainGutterResultContentText.Append("빗물받이를 설치하였다.\n");
                this.rainGutterResultContentText.Append("이제 빈 병이 있다면 비가 올 때 식수를 보충할 수 있다.\n");

                this.rainGutterLoadingTitle.text = "빗물받이를 설치하는 중...";
                
                break;
            
            case RainGutterPanelType.SUCCESS :
                needLoading = true;

                this.rainGutterResultTitleText = "작업 완료";
                this.rainGutterResultContentText.Clear();

                this.rainGutterResultContentText.Append("- 결과\n");
                this.rainGutterResultContentText.Append("빈 통에 물을 모두 채웠다.\n");
                this.rainGutterResultContentText.Append("식수을 보충했으니 이제 두려울 것이 없다.\n");
                this.rainGutterResultContentText.Append("오늘도 힘쎄고 강한 아침 햇살이 나를 감싼다.\n");

                this.rainGutterLoadingTitle.text = "식수를 보충하는 중...";
                
                break;
            
            case RainGutterPanelType.NO_CANS :
                needLoading = false;

                this.rainGutterResultTitleText = "물을 채울 수 없음";
                this.rainGutterResultContentText.Clear();

                this.rainGutterResultContentText.Append("- 결과\n");
                this.rainGutterResultContentText.Append("물을 보관할 통이 없다.\n");
                this.rainGutterResultContentText.Append("주변을 탐색하여 물병을 쏠 재료를 찾아보자.\n");
                
                break;
            
            case RainGutterPanelType.NO_WATER :
                needLoading = false;

                this.rainGutterResultTitleText = "물을 채울 수 없음";
                this.rainGutterResultContentText.Clear();

                this.rainGutterResultContentText.Append("- 결과\n");
                this.rainGutterResultContentText.Append("남은 물이 더 이상 없다.\n");
                this.rainGutterResultContentText.Append("이제 남은 건 기우재 뿐이다. 우주의 기운을 빌어보자.\n");
                
                break;
        }
        
        this.rainGutterResultTitle.text = this.rainGutterResultTitleText;
        this.rainGutterResultContent.text = this.rainGutterResultContentText.ToString();
        
        this.rainGutterLoadingPanel.SetActive(needLoading);
        this.rainGutterResultPanel.SetActive(true);
    }
}