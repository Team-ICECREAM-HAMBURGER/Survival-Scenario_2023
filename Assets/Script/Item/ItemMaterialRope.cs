public class ItemMaterialRope : Item {
    public override void Init() {
        base.Init();

        this.ItemType = GameControlType.Item.ROPE;
        this.ItemNameText = "노끈";
        this.ItemExplanationText = "절대 고리에 목을 넣지 마시오.";
    }
    
    public override void ItemUse(int value = 1) {
    }

    public override void ItemDrop(int value = 1) {
    }

    public override void ItemAdd(int value = 1) {
    }
}
