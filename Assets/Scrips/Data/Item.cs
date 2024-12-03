using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "inventory/item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public string type;
    public int value;
    public Sprite image;
}