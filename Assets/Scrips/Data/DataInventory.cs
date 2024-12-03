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
        items.Add(item);
        FindObjectOfType<UIMangager>().UpdateGameState(UIMangager.GameState.inventoryUI);
    }
    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }
}
