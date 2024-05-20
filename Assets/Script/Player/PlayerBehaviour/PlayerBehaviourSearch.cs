using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerBehaviourSearch : MonoBehaviour, IPlayerBehaviour {   // Presenter
    [SerializeField] private GameObject canvasObject;   // TODO: 삭제 예정
    
    [Space(10f)]
    
    [Header("Require Status")]
    [SerializeField] private float requireStatusStamina;
    [SerializeField] private float requireStatusBodyHeat;
    [SerializeField] private float requireStatusHydration;
    [SerializeField] private float requireStatusCalories;
    
    [Space(10f)]

    [SerializeField] private GameObject searchResultPanel;
    [SerializeField] private TMP_Text searchResultTitle;
    [SerializeField] private TMP_Text searchResultContent;

    [Space(10f)]
    
    [SerializeField] private GameObject searchLoadingPanel;
    [SerializeField] private TMP_Text searchLoadingTitle;
    
    private IGameRandomEvent[] randomEvents;
    private float weightSum;
    private float weightLimit;


    private void Init() {
        this.weightSum = 0;
        this.weightLimit = 0;
        this.randomEvents = this.canvasObject.GetComponents<IGameRandomEvent>();
    }

    private void Awake() {
        Init();
    }

    public void Behaviour() {
        // Player Status Update
        Player.Instance.StatusUpdate(
            this.requireStatusStamina, 
            this.requireStatusBodyHeat, 
            this.requireStatusHydration, 
            this.requireStatusCalories);
        
        // Player Status Effects Invoke
        Player.Instance.StatusEffectUpdate();
        
        // Random Event; Search
        RandomEventCall();
        
        World.Instance.WorldTimeUpdate(5);
    }
    
    private void RandomEventCall() {
        this.weightSum = 0;
        this.weightLimit = Random.Range(0, 100);
        
        foreach (var VARIABLE in this.randomEvents) {
            this.weightSum += VARIABLE.Weight;
            
            if (this.weightSum > this.weightLimit) {
                VARIABLE.Event();
                PanelUpdate(VARIABLE.EventResult());
                break;
            }
        }
    }
    
    private void PanelUpdate((string, string) value) {
        this.searchLoadingTitle.text = "주변을 탐색하는 중...";
        this.searchResultTitle.text = value.Item1;
        this.searchResultContent.text = value.Item2;
        
        this.searchLoadingPanel.SetActive(true);
        this.searchResultPanel.SetActive(true);
    }
}