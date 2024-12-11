using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    Item item;
    public void SetItem(Item item)
    {
        this.item = item;
    }
    public void Remove()
    {
        DataMangager.instance.RemoveItem(item);
        Destroy(this.gameObject);
    }
    public void UseItem()
    {
        DataMangager.instance.UseItemInventory(item);
        UIMangager.instance.InventorySlotUI();
    }
}
