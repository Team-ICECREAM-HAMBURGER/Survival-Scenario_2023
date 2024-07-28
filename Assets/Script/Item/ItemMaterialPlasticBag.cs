public class ItemMaterialPlasticBag : Item {
    public override void Init() {
        base.Init();

        this.ItemType = GameControlType.Item.PLASTIC_BAG;
        this.ItemNameText = "비닐 봉투";
        this.ItemExplanationText = "환경을 위해 외면받던 존재였으나, 지금만큼은 그 질긴 생존력을 존경하게 됩니다. 좋은 재료를 구했으니 이제 남은 건 창의력이군요.";
    }
    
    public override void ItemUse(int value = 1) {
    }

    public override void ItemDrop(int value = 1) {
    }

    public override void ItemAdd(int value = 1) {
    }
}
