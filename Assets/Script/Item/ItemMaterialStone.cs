public class ItemMaterialStone : Item {
    public override void Init() {
        base.Init();

        this.ItemType = GameControlType.Item.STONE;
        this.ItemNameText = "돌";
        this.ItemExplanationText = "인간은 석기를 만들고, 석기는 인간을 만들었습니다. 돌, 불, 나무만 있다면 두려울 게 없죠.";
    }
    
    public override void ItemUse(int value = 1) {
    }

    public override void ItemDrop(int value = 1) {
    }

    public override void ItemAdd(int value = 1) {
    }
}
