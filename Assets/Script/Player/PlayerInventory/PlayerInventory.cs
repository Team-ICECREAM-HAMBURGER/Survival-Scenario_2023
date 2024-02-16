using System;

public class PlayerInventory : Player {
    public void InventoryAdd(GameTypeItem gameType) {   // 인벤토리에 type 아이템을 추가
        if (InventoryCheck(gameType)) {
            return;
        }
        
        base.information.inventory.Add(gameType, base.itemDictionary[gameType]);
    }

    public void InventoryRemove(GameTypeItem gameType) {    // 인벤토리에서 type 아이템 제거
        if (!InventoryCheck(gameType)) {
            return;
        }

        this.information.inventory.Remove(gameType);
    }
}