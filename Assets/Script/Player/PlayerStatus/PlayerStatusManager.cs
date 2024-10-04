using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusManager : GameControlSingleton<PlayerStatusManager> {
    [field: SerializeField] public GameControlDictionary.PlayerStatus Statuses { get; private set; }

    public void Init() {
        foreach (var VARIABLE in this.Statuses) {   
            VARIABLE.Value.Init();
        }
    }

    public void StatusEffectUpdate((GameControlType.StatusEffect, GameControlType.StatusEffectUpdateType) value) {
        switch (value.Item2) {
            case GameControlType.StatusEffectUpdateType.EFFECT_ADD:
                PlayerStatusEffectManager.Instance.StatusEffectAdd(value.Item1);
                break;
            case GameControlType.StatusEffectUpdateType.EFFECT_REMOVE:
                PlayerStatusEffectManager.Instance.StatusEffectRemove(value.Item1);
                break;
        }
    }
    
    public void StatusUpdate((GameControlType.Status, float) value) {
        this.Statuses[value.Item1].StatusUpdate(value.Item2);
    }

    public void StatusUpdate(List<(GameControlType.Status, float)> value) {
        // TODO: 아이템의 효과가 복수의 Status에 영향을 미치면 해당 메서드를 사용 중; 이벤트 메서드로 변경 가능 여부 확인 필요.
        foreach (var VARIABLE in value) {
            this.Statuses[VARIABLE.Item1].StatusUpdate(VARIABLE.Item2);
        }
    }
    
    public void PlayerDeath(GameControlType.PlayerDeath type) {
        switch (type) {
            case GameControlType.PlayerDeath.DEATH_COLDNESS :
                GameEventManager.Instance.GameOverBadEnding(("동사했습니다.", "추위가 더위로 바뀌어갑니다.\n문득 몰려오는 아늑함에 눈꺼풀이 감깁니다..."));
                break;
            case GameControlType.PlayerDeath.DEATH_DEHYDRATION :
                GameEventManager.Instance.GameOverBadEnding(("갈사했습니다.", "목이 타들어갑니다.\n한계를 느낄 무렵 시야가 흐려지기 시작합니다..."));
                break;
            case GameControlType.PlayerDeath.DEATH_EXHAUSTION :
                break;
            case GameControlType.PlayerDeath.DEATH_HUNGER :
                GameEventManager.Instance.GameOverBadEnding(("아사했습니다.", "굶주림을 느낄 기력조차 남지 않았습니다.\n이제 남은 건 졸음 뿐입니다..."));
                break;
            case GameControlType.PlayerDeath.DEATH_INJURED :
                break;
        }
    }
}