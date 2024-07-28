public class ItemMaterialWood : Item {
    public override void Init() {
        base.Init();

        this.ItemType = GameControlType.Item.WOOD;
        this.ItemNameText = "나무";
        this.ItemExplanationText = "누구 말처럼 아낌없이 줍니다. 그러니 아낌없이 써줍시다.";
    }
    
    public override void ItemUse(int value = 1) {
    }

    public override void ItemDrop(int value = 1) {
    }

    public override void ItemAdd(int value = 1) {
    }
}
