using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState state;
    public static event Action<GameState> OnGameStateChanged;
    public Player player;
    public GameObject backPack;
    public Health healthUI;
    public EnergyUI energyUI;
    public UIMangager uiMangager;
    int hpMax = 100;
    [SerializeField] int energyMax = 4;
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
        StartCoroutine(player.TakeEnergy());
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
    void PlayerHealth()
    {
        player.hpNow = hpMax;
        if (healthUI != null)
        {
            healthUI.updateBar(player.hpNow, hpMax);
        }
    }
    public void UpdatePlayerHealth()
    {
        if (healthUI != null)
        {
            healthUI.updateBar(player.hpNow, hpMax);
        }
    }
    void PlayerEnergy()
    {
        player.energyPlayer = energyMax;
        if (healthUI != null)
        {
            energyUI.updateBar(player.energyPlayer, energyMax);
        }
    }
    public void UpdatePlayerEnergy()
    {

        if (healthUI != null)
        {
            energyUI.updateBar(player.energyPlayer, energyMax);
        }
    }
    public void InventorySlotUI()
    {
        uiMangager.InventorySlotUI();
    }
    public void RecoveryEnergyItem(int itemRecovery)
    {
        player.RecoveryEnergyItem(itemRecovery);
    }
    public void Attack()
    {
        player.Attack();
    }
    public enum GameState
    {
        start,
        end

    }
}
