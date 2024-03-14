using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Gameplay,
        Paused,
        GameOver

    }

    public GameState currentState;

    void Update()
    {

        switch (currentState)
        {
            case GameState.Gameplay:
                break;
            case GameState.Paused:
                break;
            case GameState.GameOver:
                break;

            default:
                Debug.Log("NO STATE");
                break;

        }
    
    }

}


