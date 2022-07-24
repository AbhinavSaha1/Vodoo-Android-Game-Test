using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
    Start,
    Playing,
    Win,
    Lose
}


public class GameManager : MonoBehaviour
{
    private LevelDataHolder _levelRef;
    public GameState GameState;
    public GameObject WinScreen;
    public GameObject LoseScreen;
    public GameObject StartMenu;

    void Start()
    {
        _levelRef = GameObject.FindObjectOfType<LevelDataHolder>();
        GameState = GameState.Start;
        StartMenu.SetActive(true);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameState == GameState.Start)
        {
            StartMenu.SetActive(false);
            GameState = GameState.Playing;
        }
       
        if (GameState == GameState.Win)
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
        _levelRef.CurrentLevel += 1;
        SceneManager.LoadScene(0);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);    
    }
}
