using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMangager : MonoBehaviour
{
    public static DataMangager instance;
    public DataInventory dataInventory;
    public GameState state;
    public GameManager gameManager;
    public static event Action<GameState> OnGameStateChanged;
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
    public void Add(Item item)
    {
        if (item.IsStack())
        {
            bool itemAlreadyInventory = false;
            foreach (Item inventoryItem in DataInventory.instance.items)
            {
                if (inventoryItem.itemtype == item.itemtype)
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInventory = true;
                    UIMangager.instance.InventorySlotUI();
                }
            }
            if (!itemAlreadyInventory)
            {
                item.amount += 1;
                dataInventory.items.Add(item);
                UIMangager.instance.InventorySlotUI();
            }
        }
        else
        {
            dataInventory.items.Add(item);
            UIMangager.instance.InventorySlotUI();
        }

    }
    public void RemoveItem(Item item)
    {
        dataInventory.items.Remove(item);
    }
    public void RecoveryEnergyItem(int itemRecovery)
    {
        gameManager.player.RecoveryEnergyItem(itemRecovery);
    }
    public void UseItemInventory(Item item)
    {
        item.amount -= 1;
        if (item.amount == 0)
        {
            RemoveItem(item);
        }
        switch (item.itemtype)
        {
            case Itemtype.energy:
                RecoveryEnergyItem(item.value);
                break;
            case Itemtype.hp:
                RecoveryEnergyItem(item.value);
                break;
        }
    }
    public enum GameState
    {
        start,
        end

    }

}
