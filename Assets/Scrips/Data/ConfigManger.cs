using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class ConfigManger
{
    public static ConfigManger instance;
    public ConfigManger()
    {
        instance = this;
    }
    Dictionary<int, ItemConfig> dictItemConfig = new Dictionary<int, ItemConfig>();
    public ItemConfig GetItemConfigById(int id)
    {
        return dictItemConfig[id];
    }
}
