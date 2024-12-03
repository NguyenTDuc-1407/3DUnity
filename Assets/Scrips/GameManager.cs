using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState state;
    public static event Action<GameState> OnGameStateChanged;
    public DataMangager dataMangager;
    public Player player;
    public GameObject backPack;
    public UIMangager uiMangager;
    int hpMax = 100;
    int energyMax = 80;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        backPack.SetActive(false);
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
            case GameState.inventoryItem:
                break;
            case GameState.playerAtack:
                Attack();
                break;
            case GameState.palyerPickUp:
                break;
            case GameState.end:
                break;

        }
        OnGameStateChanged?.Invoke(newState);
    }
    void PlayerHealth()
    {
        player.hpNow = hpMax;
        if (uiMangager.healthUI != null)
        {
            uiMangager.healthUI.updateBar(player.hpNow, hpMax);
        }
    }
    void PlayerEnergy()
    {
        player.energyNow = energyMax;
        if (uiMangager.healthUI != null)
        {
            uiMangager.healthUI.updateBar(player.energyNow, energyMax);
        }
    }
    void Attack()
    {
        player.Attack();
    }
    public enum GameState
    {
        start,
        playerAtack,
        palyerPickUp,
        inventoryItem,
        end

    }
}
