public class ItemMaterialCan : Item {
    public override void Init() {
        base.Init();

        this.ItemType = GameControlType.Item.CAN;
        this.ItemNameText = "빈 캔";
        this.ItemExplanationText = "물을 담을 수 있는 훌륭하게 조잡한 물통이자, 참호전의 영원한 친구입니다. 사실 지금 상황도 참호전이랑 딱히 다르진 않지만 그건 중요하지 않습니다.";
    }
    
    public override void ItemUse(int value = 1) {
    }

    public override void ItemDrop(int value = 1) {
    }

    public override void ItemAdd(int value = 1) {
    }
}
