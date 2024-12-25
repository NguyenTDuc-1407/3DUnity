using System;
using System.Collections.Generic;
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
    public Enemy enemy;
    public List<ItemDatas> itemDatas = new List<ItemDatas>();
    public ItemDatas itemData;
    public int hpMax = 100;
    public int hpMaxEnemy = 20;
    public int energyMax = 4;
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
                StartCoroutine(player.TakeEnergy());
                ManagerConfig();
                break;
            case GameState.end:
                break;

        }
        OnGameStateChanged?.Invoke(newState);
    }
    public void Attack()
    {
        player.Attack();
    }
    public void TakeDamagePlayer(int damage)
    {
        player.DamePlayer(damage);
    }
    public void TakeDameEnemy(int damage)
    {
        if (enemy.checkDead == false)
        {
            enemy.DameEnemy(damage);
        }
    }
    public void ManagerConfig()
    {
        Debug.Log(itemDatas);
    }
    public enum GameState
    {
        start,
        end

    }
}
