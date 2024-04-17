public class GameControlType {
    public enum Behaviour {
        CRAFT,       // 제작하기
        FIRE,       // 모닥불
        MOVE,       // 이동하기
        OUTSIDE,    // 야외
        REST,       // 휴식 취하기
        SEARCH,     // 탐색하기
        SHELTER,    // 휴식처
        SLEEP,      // 잠자기
        WATER,      // 빗물 모으기
    }
    
    public enum RandomEvent {
        FARMING,    // 아이템 수집
        HUNTING,    // 동물 사냥
        DANGER,     // 위험에 빠짐
        INJURED     // 부상을 입음
    }
    
    public enum Item {
        MATERIAL,   // 재료
        FOOD,       // 음식
        TOOL,       // 도구
        WEAPON,     // 무기
        GEAR        // 장비
    }
    
    public enum Status {
        STAMINA,    // 체력
        BODY_HEAT,  // 체온
        HYDRATION,  // 수분
        CALORIES    // 칼로리
    }
    
    public enum StatusEffect {
        NO_SHELTER,     // 휴식처가 없음
        NO_FIRE,        // 불이 없음
        INJURED,        // 부상을 입음
        DEHYDRATION,    // 탈수
        EXHAUSTION,     // 탈진
        HYPOTHERMIA     // 저체온증
    }
}