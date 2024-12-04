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
        DataInventory.instance.RemoveItem(item);
        Destroy(this.gameObject);
    }
    public void UseItem()
    {
        item.amount -= 1;
        if (item.amount == 0)
        {
            Remove();
        }
        switch (item.itemtype)
        {
            case Itemtype.energy:
                GameManager.instance.RecoveryEnergyItem(item.value);
                break;
            case Itemtype.hp:
                GameManager.instance.RecoveryEnergyItem(item.value);
                break;
        }
           GameManager.instance.InventorySlotUI();
    }
}
