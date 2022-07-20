using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Start,
    Playing,
    Win,
    Lose
}


public class GameManager : MonoBehaviour
{
    public GameState GameState;
    public int CurrentLevel;
    public GameObject WinScreen;
    public GameObject LoseScreen;

    void Start()
    {
        GameState = GameState.Playing;
    }


    void Update()
    {
        if(GameState == GameState.Win)
        {
            YouWin();
        }
        if (GameState == GameState.Lose)
        {
            YouLose();
        }
    }
    public void YouWin()
    {
        WinScreen.SetActive(true);
    }
    public void  YouLose()
    {
        LoseScreen.SetActive(true);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(CurrentLevel + 1);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(CurrentLevel);
    }
}
