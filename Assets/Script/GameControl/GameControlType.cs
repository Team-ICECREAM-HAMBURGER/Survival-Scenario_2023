public class GameControlType {
    public enum Behaviour {
        OUTSIDE,
        MOVE,
        SEARCH,
        FIRE,
        SHELTER,
        INVENTORY
    }
    
    public enum RandomEvent {
        FARM,    // 아이템 수집
        HUNT,    // 동물 사냥
        INJURED     // 부상을 입음
    }

    public enum Weather {
        CLEAR,
        RAIN,
        SNOW,
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
        PLASTIC_BAG,
        ROPE,
        STONE,
        TINDER,
        WOOD,
        
        // 도구
        FIRE_TOOL,
        GATHERING_TOOL,
        HUNTING_TOOL,
        RAIN_GUTTER,
        SHELTER,
    }

    public enum ItemGetRoot {
        CRAFT,      // 제작하기
        COOK,       // 요리하기
        FARM,       // 탐색하기
        HUNT,       // 사냥하기
        WATER,       // 빗물 모으기
    }
    
    public enum Status {
        STAMINA = 0,    // 체력
        BODY_HEAT = 1,  // 체온
        HYDRATION = 2,  // 수분
        CALORIES = 3    // 칼로리
    }
    
    public enum StatusEffect {
        COLDNESS,       // 추위 (체온)
        DEHYDRATION,    // 탈수 (수분)
        EXHAUSTION,     // 탈진 (체력)
        HUNGER,         // 기아 (칼로리)
        INJURED,        // 부상
    }
}