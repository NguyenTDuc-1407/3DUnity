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
}
public enum Itemtype
{
    hp, energy
}
