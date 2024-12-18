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
    public List<Enemy> enemy;
    public int hpMax = 100;
    public int hpMaxEnemy = 20;
    [SerializeField] public int energyMax = 4;
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
    public void TakeDamagePlayer(int damage){
        player.DamePlayer(damage);
    }
    // public void TakeDameEnemy(int damage){
    //     enemy[0].DameEnemy(damage);
    // }
    public enum GameState
    {
        start,
        end

    }
}
