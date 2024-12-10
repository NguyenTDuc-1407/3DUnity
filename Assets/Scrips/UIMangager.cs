using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMangager : MonoBehaviour
{
    public static UIMangager instance;
    public GameState state;
    public static event Action<GameState> OnGameStateChanged;
    public InventoryUI inventoryUI;
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
   public void InventorySlotUI()
    {
        inventoryUI.DisplayInventory();
    }
    public enum GameState
    {
        start,
        end

    }

}
