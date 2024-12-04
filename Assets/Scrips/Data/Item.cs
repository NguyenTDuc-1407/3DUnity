using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "inventory/item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Itemtype itemtype;
    public Sprite image;
    public int amount;
    public bool IsStack()
    {
        switch (itemtype)
        {
            default:
            case Itemtype.energy:
            case Itemtype.hp:
                return true;
        }
    }
}
public enum Itemtype
{
    hp, energy
}
