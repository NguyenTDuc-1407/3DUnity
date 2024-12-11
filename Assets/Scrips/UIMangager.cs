using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMangager : MonoBehaviour
{
    public static UIMangager instance;
    public GameState state;
    public GameManager gameManager;
    public static event Action<GameState> OnGameStateChanged;
    public InventoryUI inventoryUI;
    public Health healthUI;
    public EnergyUI energyUI;
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
                PlayerHealth();
                PlayerEnergy();
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
    public void PlayerHealth()
    {
        gameManager.player.hpNow = gameManager.hpMax;
        if (healthUI != null)
        {
            healthUI.updateBar(gameManager.player.hpNow, gameManager.hpMax);
        }
    }
    public void UpdatePlayerHealth()
    {
        if (healthUI != null)
        {
            healthUI.updateBar(gameManager.player.hpNow, gameManager.hpMax);
        }
    }
    public void PlayerEnergy()
    {
        gameManager.player.energyPlayer = gameManager.energyMax;
        if (healthUI != null)
        {
            energyUI.updateBar(gameManager.player.energyPlayer, gameManager.energyMax);
        }
    }
    public void UpdatePlayerEnergy()
    {

        if (healthUI != null)
        {
            energyUI.updateBar(gameManager.player.energyPlayer, gameManager.energyMax);
        }
    }
    public void RecoveryEnergyItem(int itemRecovery)
    {
        gameManager.player.RecoveryEnergyItem(itemRecovery);
    }
    public enum GameState
    {
        start,
        end

    }

}
