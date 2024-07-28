public class ItemMaterialPieceOfCloth : Item {
    public override void Init() {
        base.Init();

        this.ItemType = GameControlType.Item.PIECE_OF_CLOTH;
        this.ItemNameText = "옷감";
        this.ItemExplanationText = "찢겨지고 더렵혀진 옷감입니다. 재료라면 몰라도 입을 수는 없겠군요. ...엄한 생각 마세요. 사형입니다, 사형.";
    }
    
    public override void ItemUse(int value = 1) {
    }

    public override void ItemDrop(int value = 1) {
    }

    public override void ItemAdd(int value = 1) {
    }
}
