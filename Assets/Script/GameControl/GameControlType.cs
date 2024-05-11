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
        // 식량
        BERRY,
        BOTTLE_OF_WATER,
        COOKED_MEAT,
        ENERGY_BAR,
        MRE,
        RAW_MEAT,
        
        // 재료
        ANIMAL_SKIN,
        CAN,
        PIECE_OF_CLOTH,
        ROPE,
        STONE,
        TINDER,
        WOOD,
        
        // 도구
        FIRE_TOOL,
        GATHERING_TOOL,
        HUNTING_TOOL,
    }
    
    public enum Status {
        STAMINA = 0,    // 체력
        BODY_HEAT = 1,  // 체온
        HYDRATION = 2,  // 수분
        CALORIES = 3    // 칼로리
    }
    
    public enum StatusEffect {
        INJURED,        // 부상
        EXHAUSTION,     // 탈진 (체력)
        COLDNESS,       // 추위 (체온)
        DEHYDRATION,    // 탈수 (수분)
        HUNGER,         // 기아 (칼로리)
    }
}