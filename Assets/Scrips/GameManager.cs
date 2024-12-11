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
    public int hpMax = 100;
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
    public enum GameState
    {
        start,
        end

    }
}
