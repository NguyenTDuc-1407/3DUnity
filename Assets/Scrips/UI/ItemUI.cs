using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    ItemDatas itemDatas;
    public void SetItem(ItemDatas itemDatas)
    {
        this.itemDatas = itemDatas;
    }
    public void Remove()
    {
        DataMangager.instance.RemoveItem(itemDatas);
        Destroy(this.gameObject);
    }
    public void UseItem()
    {
        DataMangager.instance.UseItemInventory(itemDatas);
        UIMangager.instance.InventorySlotUI();
    }
}
