using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBehaviourRainGutter : PlayerBehaviour {
    [Space(25f)]

    [Header("Behaviour Require Item")] 
    [field: SerializeField] private UnityEvent OnItemUseRainGutter;

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

    private static int GUTTER_SET_ROPE = 1;
    private static int GUTTER_SET_WOOD = 2;
    private static int GUTTER_SET_PLASTIC_BAG = 1;
    
    private readonly List<(GameControlType.Item, int)> rainGutterSetMaterialList = new() {
        (GameControlType.Item.ROPE, GUTTER_SET_ROPE),
        (GameControlType.Item.WOOD, GUTTER_SET_WOOD),
        (GameControlType.Item.PLASTIC_BAG, GUTTER_SET_PLASTIC_BAG)
    };
    
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
    
    private bool CanBehaviour(List<(GameControlType.Item, int)> value) {
        return PlayerBehaviourManager.Instance.CanBehaviour(value);
    }
    
    public override void Behaviour() {
        if (!CanBehaviour()) {    // Hasn't Rain Gutter
            // Material Check
            if (CanBehaviour(this.rainGutterSetMaterialList)) {
                PlayerBehaviourManager.Instance.WorldRainGutterSet(true);
                PanelUpdate(GameControlType.RainGutterPanelType.PASS);
                
                this.OnItemUseRainGutter.Invoke();
                this.OnPlayerStatusUpdate.Invoke();
            }
            else {
                // ERROR; NO MATERIALS
                PlayerBehaviourManager.Instance.WorldRainGutterSet(false);
                PanelUpdate(GameControlType.RainGutterPanelType.NO_MATERIALS);
            }
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
                    PanelUpdate(GameControlType.RainGutterPanelType.SUCCESS);
                }
                else {  // No Empty Can;
                    // ERROR; NO_CANS
                    PanelUpdate(GameControlType.RainGutterPanelType.NO_CANS);
                }
            }
            else {
                if (PlayerBehaviourManager.Instance.WorldRainWaterGet()) { // Water Left
                    if (emptyCans > 0) {  // Has Empty Can
                        // Get Water
                        PlayerBehaviourManager.Instance.ItemUse((GameControlType.Item.CAN, emptyCans));
                        PlayerBehaviourManager.Instance.ItemAdd((GameControlType.Item.BOTTLE_OF_WATER, emptyCans));
                        
                        // Loading
                        PanelUpdate(GameControlType.RainGutterPanelType.SUCCESS);
                    }
                    else {
                        // ERROR; NO_CANS
                        PanelUpdate(GameControlType.RainGutterPanelType.NO_CANS);
                    }
                    
                    PlayerBehaviourManager.Instance.WorldRainWaterSet(false);
                }
                else {
                    // ERROR; NO_WATER
                    PanelUpdate(GameControlType.RainGutterPanelType.NO_WATER);
                }
            }
        }
        
        // World Info. Update
        PlayerBehaviourManager.Instance.WorldTimeUpdate(this.makeRainGutterSpendTime);
        
        // Game Data Save
        PlayerBehaviourManager.Instance.GameDataSaveInvoke();
    }

    private void PanelUpdate(GameControlType.RainGutterPanelType type) {
        var needLoading = false;

        this.rainGutterResultTitleText = String.Empty;
        this.rainGutterResultContentText.Clear();
        
        switch (type) {
            case GameControlType.RainGutterPanelType.PASS :
                needLoading = true;
                
                this.rainGutterResultTitleText = "작업 완료";
                this.rainGutterResultContentText.Clear();

                this.rainGutterResultContentText.Append("- 결과\n");
                this.rainGutterResultContentText.Append("빗물받이를 설치하였다.\n");
                this.rainGutterResultContentText.Append("이제 빈 병이 있다면 비가 올 때 식수를 보충할 수 있다.\n");

                this.rainGutterLoadingTitle.text = "빗물받이를 설치하는 중...";
                
                break;
            
            case GameControlType.RainGutterPanelType.SUCCESS :
                needLoading = true;

                this.rainGutterResultTitleText = "작업 완료";
                this.rainGutterResultContentText.Clear();

                this.rainGutterResultContentText.Append("- 결과\n");
                this.rainGutterResultContentText.Append("빈 통에 물을 모두 채웠다.\n");
                this.rainGutterResultContentText.Append("식수을 보충했으니 이제 두려울 것이 없다.\n");
                this.rainGutterResultContentText.Append("오늘도 힘쎄고 강한 아침 햇살이 나를 감싼다.\n");

                this.rainGutterLoadingTitle.text = "식수를 보충하는 중...";
                
                break;
            
            case GameControlType.RainGutterPanelType.NO_CANS :
                needLoading = false;

                this.rainGutterResultTitleText = "물을 채울 수 없음";
                this.rainGutterResultContentText.Clear();

                this.rainGutterResultContentText.Append("- 결과\n");
                this.rainGutterResultContentText.Append("물을 보관할 통이 없다.\n");
                this.rainGutterResultContentText.Append("주변을 탐색하여 물병을 쏠 재료를 찾아보자.\n");
                
                break;
            
            case GameControlType.RainGutterPanelType.NO_WATER :
                needLoading = false;

                this.rainGutterResultTitleText = "물을 채울 수 없음";
                this.rainGutterResultContentText.Clear();

                this.rainGutterResultContentText.Append("- 결과\n");
                this.rainGutterResultContentText.Append("남은 물이 더 이상 없다.\n");
                this.rainGutterResultContentText.Append("이제 남은 건 기우재 뿐이다. 우주의 기운을 빌어보자.\n");
                
                break;
            
            case GameControlType.RainGutterPanelType.NO_MATERIALS :
                needLoading = false;

                this.rainGutterResultTitleText = "재료가 부족함";
                this.rainGutterResultContentText.Clear();

                this.rainGutterResultContentText.Append("- 결과\n");
                this.rainGutterResultContentText.Append("빗물 받이를 설치할 재료가 부족하다.\n");
                this.rainGutterResultContentText.Append("재료를 모아서 다시 시도해보자.\n");

                this.rainGutterResultContentText.Append("\n");
                
                this.rainGutterResultContentText.Append("- 필요한 아이템\n");
                
                // Require Items for RainGutter;
                this.rainGutterResultContentText.Append(PlayerBehaviourManager.Instance.GetItemName(GameControlType.Item.WOOD));
                this.rainGutterResultContentText.Append(" ");
                this.rainGutterResultContentText.Append(GUTTER_SET_WOOD);
                this.rainGutterResultContentText.Append("개\n");
        
                this.rainGutterResultContentText.Append(PlayerBehaviourManager.Instance.GetItemName(GameControlType.Item.ROPE));
                this.rainGutterResultContentText.Append(" ");
                this.rainGutterResultContentText.Append(GUTTER_SET_ROPE);
                this.rainGutterResultContentText.Append("개\n");
        
                this.rainGutterResultContentText.Append(PlayerBehaviourManager.Instance.GetItemName(GameControlType.Item.PLASTIC_BAG));
                this.rainGutterResultContentText.Append(" ");
                this.rainGutterResultContentText.Append(GUTTER_SET_PLASTIC_BAG);
                this.rainGutterResultContentText.Append("개\n");
                
                break;
        }
        
        this.rainGutterResultTitle.text = this.rainGutterResultTitleText;
        this.rainGutterResultContent.text = this.rainGutterResultContentText.ToString();
        
        this.rainGutterLoadingPanel.SetActive(needLoading);
        this.rainGutterResultPanel.SetActive(true);
    }
}