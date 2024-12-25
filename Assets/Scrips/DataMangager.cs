using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMangager : MonoBehaviour
{
    public static DataMangager instance;
    public GameState state;
    public GameManager gameManager;
    public static event Action<GameState> OnGameStateChanged;
    ConfigManger configManger;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        UpdateGameState(GameState.start);
    }
    public void UpdateGameState(GameState newState)
    {
        state = newState;
        switch (newState)
        {
            case GameState.start:
                break;
            case GameState.end:
                break;

        }
        OnGameStateChanged?.Invoke(newState);
    }
    public void Add(ItemConfig itemConfig)
    {
        if (ConfigInventory.instance.itemConfigs != null)
        {
            GameManager.instance.itemData.id = 1;
            configManger.GetItemConfigById(GameManager.instance.itemData.id);
            Debug.Log(GameManager.instance.itemData.id);
            if (itemConfig.IsStack())
            {
                bool itemAlreadyInventory = false;
                foreach (ItemConfig inventoryItem in ConfigInventory.instance.itemConfigs)
                {
                    if (inventoryItem.id == itemConfig.id)
                    {
                        // GameManager.instance.itemData.amount += 1;
                        itemAlreadyInventory = true;
                        UIMangager.instance.InventorySlotUI();
                    }
                }
                if (!itemAlreadyInventory)
                {
                    // GameManager.instance.itemData.amount += 1;
                    ConfigInventory.instance.itemConfigs.Add(itemConfig);
                    UIMangager.instance.InventorySlotUI();
                }
            }
            else
            {
                ConfigInventory.instance.itemConfigs.Add(itemConfig);
                UIMangager.instance.InventorySlotUI();
            }
        }

    }
    public void RemoveItem(ItemDatas itemDatas)
    {
        GameManager.instance.itemDatas.Remove(itemDatas);

    }
    public void RecoveryEnergyItem(int itemRecovery)
    {
        gameManager.player.RecoveryEnergyItem(itemRecovery);
    }
    public void UseItemInventory(ItemDatas itemDatas)
    {
        itemDatas.id = configManger.GetItemConfigById(itemDatas.id).id;
        itemDatas.amount -= 1;
        if (itemDatas.amount == 0)
        {
            RemoveItem(itemDatas);
        }
        switch (configManger.GetItemConfigById(itemDatas.id).itemtype)
        {
            case Itemtype.Energy:
                RecoveryEnergyItem(configManger.GetItemConfigById(itemDatas.id).value);
                break;
            case Itemtype.Hp:
                RecoveryEnergyItem(configManger.GetItemConfigById(itemDatas.id).value);
                break;
        }
    }
    public enum GameState
    {
        start,
        end

    }

}
