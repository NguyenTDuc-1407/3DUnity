// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class DataMangager : MonoBehaviour
// {
//     public static DataMangager instance;
//     public DataInventory dataInventory;
//     public GameState state;
//     public static event Action<GameState> OnGameStateChanged;
//     private void Awake()
//     {
//      if (instance == null)
//         {
//             instance = this;
//         }
//     }
//     void Start()
//     {
//         UpdateGameState(GameState.start);
//     }
//     public void UpdateGameState(GameState newState)
//     {
//         state = newState;
//         switch (newState)
//         {
//             case GameState.start:
//                 break;
//             case GameState.updateData:
//                 break;
//             case GameState.RemoveItemData:
//                 break;
//             case GameState.end:
//                 break;

//         }
//         OnGameStateChanged?.Invoke(newState);
//     }
//     public enum GameState
//     {
//         start,
//         updateData,
//         RemoveItemData,
//         end

//     }

// }
