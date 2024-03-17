using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum GameState
    {
        Gameplay,
        Paused,
        GameOver,
        LevelUp

    }

    public GameState currentState;

    public GameState perviousState;

    [Header("UI")]
    public GameObject pauseScreen;
    public GameObject resultsScreen;

    public GameObject levelUpScreen;

    public TextMeshProUGUI currentHealth;
    public TextMeshProUGUI currentRecovery;
    public TextMeshProUGUI currentMoveSpeed;
    public TextMeshProUGUI CurrentMight;
    public TextMeshProUGUI currentProjectileSpeed;
    public TextMeshProUGUI currentMagnet;

    public bool isGameOver = false;
    public bool choosingUpgrade = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
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
                if (!isGameOver)
                {
                    isGameOver = true;
                    Time.timeScale = 0f;
                    DisplayResults();
                }
                break;
            
            case GameState.LevelUp:
                if(!choosingUpgrade)
                {
                    choosingUpgrade = true;
                    Time.timeScale = 0f;
                    levelUpScreen.SetActive(true);
                }
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
        if (currentState != GameState.Paused)
        {

            perviousState = currentState;
            ChangeState(GameState.Paused);
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
        }

    }

    public void ResumeGame()
    {
        if (currentState == GameState.Paused)
        {
            ChangeState(perviousState);
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);


        }

    }

    void CheckForPauseAndResume()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == GameState.Paused)
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
        resultsScreen.SetActive(false);
        levelUpScreen.SetActive(false);
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            ChangeState(GameState.GameOver);
            DisplayResults();
        }
    }

    void DisplayResults()
    {
        resultsScreen.SetActive(true);

    }


    public void StartLevelUp()
    {
        ChangeState(GameState.LevelUp);
    }

    public void EndLevelUp()
    {
        choosingUpgrade = false;
        Time.timeScale = 1f;
        levelUpScreen.SetActive(true);
        ChangeState(GameState.Gameplay);
    }


}


