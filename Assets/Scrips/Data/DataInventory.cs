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

}
