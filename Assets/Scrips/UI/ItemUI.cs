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

}
