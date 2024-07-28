using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToolHuntingTool : Item {
    public override void Init() {
        base.Init();

        this.ItemType = GameControlType.Item.HUNTING_TOOL;
        this.ItemNameText = "사냥 도구";
        this.ItemExplanationText = "사냥감을 사냥할 수 있는 사냥 도구입니다. 조잡하지만 한 방만큼은 확실하죠. 그러니 이 문구를 명심하세요. '앞면, 저 방향'";
    }
    
    public override void ItemUse(int value = 1) {
    }

    public override void ItemDrop(int value = 1) {
    }

    public override void ItemAdd(int value = 1) {
    }
}
