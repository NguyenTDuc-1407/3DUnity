using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInventory : MonoBehaviour
{
    public static DataInventory instance;
    public List<Item> items = new List<Item>();
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Add(Item item)
    {
        if (item.IsStack())
        {
            bool itemAlreadyInventory = false;
            foreach (Item inventoryItem in items)
            {
                if (inventoryItem.itemtype == item.itemtype)
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInventory = true;
                    GameManager.instance.InventorySlotUI();
                }
            }
            if (!itemAlreadyInventory)
            {
                item.amount += 1;
                items.Add(item);
                GameManager.instance.InventorySlotUI();
            }
        }
        else
        {
            items.Add(item);
            GameManager.instance.InventorySlotUI();
        }
    }
    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

}
