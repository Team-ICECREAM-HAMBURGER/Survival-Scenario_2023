using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToolGatheringTool : Item {
    public override void Init() {
        base.Init();

        this.ItemType = GameControlType.Item.GATHERING_TOOL;
        this.ItemNameText = "채집 도구";
        this.ItemExplanationText = "맨손의 시대는 끝났습니다. 채집의 효율을 극대화하기 위한 도구입니다. 그래서 어떻게 생겼냐고요? 그 질문에 답할 시간에 이 도구는 나무를 하나 더 채집합니다.";
    }
    
    public override void ItemUse(int value = 1) {
    }

    public override void ItemDrop(int value = 1) {
    }

    public override void ItemAdd(int value = 1) {
    }
}