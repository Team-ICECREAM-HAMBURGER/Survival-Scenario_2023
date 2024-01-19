using TMPro;
using UnityEngine;

public class PlayerFireTermView : MonoBehaviour {
    [SerializeField] private TMP_Text fireTermText;
    
    private int fireTerm;
    
    public delegate void FireTermUpdateHandler(int value);
    public static FireTermUpdateHandler OnFireTermUpdateEvent;


    private void Init() {
        OnFireTermUpdateEvent += FireTermUpdate;
    }

    private void Awake() {
        Init();
    }

    private void FireTermUpdate(int value) {
        this.fireTerm += value;
        this.fireTermText.text = $"모닥불 ({this.fireTerm}텀 남음)";
    }
}