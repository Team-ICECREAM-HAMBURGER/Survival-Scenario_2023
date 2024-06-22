using System;
using Random = UnityEngine.Random;

[Serializable]
public class PlayerInformationData {
    public string name = "";
    public int id = 0000;
    public GameControlDictionary.Inventory inventory = new() {
        { GameControlType.Item.BERRY, 0 },
        { GameControlType.Item.BOTTLE_OF_WATER, 0 },
        { GameControlType.Item.COOKED_MEAT, 0 },
        { GameControlType.Item.ENERGY_BAR, 0 },
        { GameControlType.Item.MRE, 0 },
        { GameControlType.Item.RAW_MEAT, 0 },

        { GameControlType.Item.ANIMAL_SKIN, 0 },
        { GameControlType.Item.CAN, 0 },
        { GameControlType.Item.PIECE_OF_CLOTH, 0 },
        { GameControlType.Item.PLASTIC_BAG, 0 },
        { GameControlType.Item.ROPE, 0 },
        { GameControlType.Item.STONE, 0 },
        { GameControlType.Item.TINDER, 0 },
        { GameControlType.Item.WOOD, 0 },

        { GameControlType.Item.FIRE_TOOL, 0 },
        { GameControlType.Item.GATHERING_TOOL, 0 },
        { GameControlType.Item.HUNTING_TOOL, 0 },
    };
    public GameControlDictionary.Status status = new() {
        { GameControlType.Status.STAMINA, 100f },
        { GameControlType.Status.BODY_HEAT, 100f },
        { GameControlType.Status.HYDRATION, 100f },
        { GameControlType.Status.CALORIES, 100f }
    };

    public GameControlDictionary.StatusEffect statusEffect = new();
}