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

    public GameState perviousState;

    [Header("UI")]
    public GameObject pauseScreen;


    void Awake() 
    {
        DisableScreens();
    }

    void Update()
    {

        switch (currentState)
        {
            case GameState.Gameplay:
                CheckForPauseAndResume();
                break;
            case GameState.Paused:
                CheckForPauseAndResume();

                break;
            case GameState.GameOver:
                break;

            default:
                Debug.Log("NO STATE");
                break;

        }
    
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
    }

    public void PauseGame()
    {
        if(currentState != GameState.Paused)
        {

            perviousState = currentState;
            ChangeState(GameState.Paused);
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
        }
        
    }

    public void ResumeGame()
    {
        if(currentState == GameState.Paused)
        {
            ChangeState(perviousState);
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);


        }

    }

    void CheckForPauseAndResume()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(currentState == GameState.Paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void DisableScreens()
    {
        pauseScreen.SetActive(false);
    }


}


