public class ItemToolFireTool : Item {
    public override void Init() {
        base.Init();

        this.ItemType = GameControlType.Item.FIRE_TOOL;
        this.ItemNameText = "점화 도구";
        this.ItemExplanationText = "불이 있으라. 그러자 불이... 앗 뜨거.";
    }
    
    public override void ItemUse(int value = 1) {
    }

    public override void ItemDrop(int value = 1) {
    }

    public override void ItemAdd(int value = 1) {
    }
}
