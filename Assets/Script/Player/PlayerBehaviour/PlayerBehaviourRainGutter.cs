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

public class PlayerBehaviourRainGutter : MonoBehaviour, IPlayerBehaviour {
    [SerializeField] private GameObject rainGutterResultPanel;
    [SerializeField] private TMP_Text rainGutterResultTitle;
    [SerializeField] private TMP_Text rainGutterResultContent;
    
    [Space(10f)] 
    
    [SerializeField] private GameObject rainGutterLoadingPanel;
    [SerializeField] private TMP_Text rainGutterLoadingTitle;

    private int spendTime;
    

    public void Init() {
        this.spendTime = 1;
    }

    public void Behaviour() {
        if (!World.Instance.HasRainGutter) {    // Hasn't Rain Gutter
            World.Instance.HasRainGutter = true;
            // Player.Instance.StatusEffectInvoke(this.spendTime);
            
            PanelUpdate(RainGutterPanelType.PASS);
        }
        else {    // Has Rain Gutter; 
            var emptyCans = Player.Instance.Inventory[GameControlType.Item.CAN];

            if (World.Instance.Weather.Item1 == GameControlType.Weather.RAIN) { // Weather: Rainy
                World.Instance.HasWater = true;
                
                if (emptyCans > 0) { // Has Empty Can;
                    // Get Water
                    ItemManager.Instance.ItemMaterials[GameControlType.Item.CAN].ItemUse(emptyCans);
                    ItemManager.Instance.ItemFoods[GameControlType.Item.BOTTLE_OF_WATER].ItemAdd(emptyCans);
                    
                    // Loading
                    PanelUpdate(RainGutterPanelType.SUCCESS);
                }
                else {  // No Empty Can;
                    // ERROR; NO_CANS
                    PanelUpdate(RainGutterPanelType.NO_CANS);
                }
            }
            else {
                if (World.Instance.HasWater) { // Water Left
                    if (emptyCans > 0) {  // Has Empty Can
                        // Get Water
                        ItemManager.Instance.ItemMaterials[GameControlType.Item.CAN].ItemUse(emptyCans);
                        ItemManager.Instance.ItemFoods[GameControlType.Item.BOTTLE_OF_WATER].ItemAdd(emptyCans);

                        // Loading
                        PanelUpdate(RainGutterPanelType.SUCCESS);
                    }
                    else {
                        // ERROR; NO_CANS
                        PanelUpdate(RainGutterPanelType.NO_CANS);
                    }
                    
                    World.Instance.HasWater = false;
                }
                else {
                    // ERROR; NO_WATER
                    PanelUpdate(RainGutterPanelType.NO_WATER);
                }
            }
        }
        
        World.Instance.TimeUpdate(this.spendTime);
        // WorldInformation.OnCurrentTimeDayCounterUpdate.Invoke(World.Instance.TimeDay);
        
        GameInformationManager.OnGameDataSaveEvent();
    }

    private void PanelUpdate(RainGutterPanelType type) {
        var title = String.Empty;
        var content = new StringBuilder();
        var needLoading = false;
        
        switch (type) {
            case RainGutterPanelType.PASS :
                needLoading = true;
                
                title = "작업 완료";
                content.Clear();

                content.Append("- 결과\n");
                content.Append("빗물받이를 설치하였다.\n");
                content.Append("이제 빈 병이 있다면 비가 올 때 식수를 보충할 수 있다.\n");

                this.rainGutterLoadingTitle.text = "빗물받이를 설치하는 중...";
                
                break;
            
            case RainGutterPanelType.SUCCESS :
                needLoading = true;

                title = "작업 완료";
                content.Clear();

                content.Append("- 결과\n");
                content.Append("빈 통에 물을 모두 채웠다.\n");
                content.Append("식수을 보충했으니 이제 두려울 것이 없다.\n");
                content.Append("오늘도 힘쎄고 강한 아침 햇살이 나를 감싼다.\n");

                this.rainGutterLoadingTitle.text = "식수를 보충하는 중...";
                
                break;
            
            case RainGutterPanelType.NO_CANS :
                needLoading = false;

                title = "물을 채울 수 없음";
                content.Clear();

                content.Append("- 결과\n");
                content.Append("물을 보관할 통이 없다.\n");
                content.Append("주변을 탐색하여 물병을 쏠 재료를 찾아보자.\n");
                
                break;
            
            case RainGutterPanelType.NO_WATER :
                needLoading = false;

                title = "물을 채울 수 없음";
                content.Clear();

                content.Append("- 결과\n");
                content.Append("남은 물이 더 이상 없다.\n");
                content.Append("이제 남은 건 기우재 뿐이다. 우주의 기운을 빌어보자.\n");
                
                break;
        }
        
        this.rainGutterResultTitle.text = title;
        this.rainGutterResultContent.text = content.ToString();
        
        this.rainGutterLoadingPanel.SetActive(needLoading);
        this.rainGutterResultPanel.SetActive(true);
    }
}