public class ItemMaterialTinder : Item {
    public override void Init() {
        base.Init();

        this.ItemType = GameControlType.Item.TINDER;
        this.ItemNameText = "불쏘시개";
        this.ItemExplanationText = "불을 피울 때 필수적인 재료이지만, 절대 책을 말하는 것이 아닙니다. 그런 줄 알았다면 나무에게 사과하세요.";
    }
    
    public override void ItemUse(int value = 1) {
    }

    public override void ItemDrop(int value = 1) {
    }

    public override void ItemAdd(int value = 1) {
    }
}
