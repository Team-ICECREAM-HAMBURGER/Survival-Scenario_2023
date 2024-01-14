using UnityEngine;

public class PlayerFire : MonoBehaviour {
    [SerializeField] private GameObject makingFireScreen;

    public delegate void MakingFireEventHandler();
    public static MakingFireEventHandler OnMakingFireEvent;
    
    
    private void Init() {
        this.makingFireScreen.SetActive(false);
        
        OnMakingFireEvent += MakingFire;
    }
    
    private void Start() {
        Init();
    }

    private void MakingFire() {
        // TODO: 메서드 구현
        
        // 불 피우는 중 애니메이션
        this.makingFireScreen.SetActive(true);
        
        // 아이템 소모; 성공 여부와 상관없이 무조건 아이템은 소모함.
        
        // 날씨에 따른 확률 결정
        // 비: 30%, 눈: 30%, 맑음: 70%
        
        // 결과 보고
        // 성공 시: OK 버튼 -> Fire 캔버스로
        // 실패 시: OK 버튼 -> Outside 캔버스로
        
    }


    private void MakingFireResultOk() {
        GameCanvasControl.OnCanvasOnEvent("Canvas Information");
        // TODO: 성공 시 Info 캔버스 활성화; 실패 시 Outside 캔버스로 복귀.
    }
}
