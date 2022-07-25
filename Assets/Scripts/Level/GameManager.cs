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
    public GameObject ScoreText;
    public GameObject DashUI;
    public bool _isLevelLoading = false;

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
            //Giving some time for the menue scene to load if OnClick event for the Menue button is triggered
            StartCoroutine(Setup());
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
        SceneManager.LoadScene(1);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(1);    
    }
    public void BackToMenu()
    {
        _isLevelLoading = true;
        SceneManager.LoadScene(0);
    }
    IEnumerator Setup()
    {
        yield return new WaitForSeconds(0.15f);
        StartMenu.SetActive(false);
        ScoreText.SetActive(true);
        DashUI.SetActive(true);
        GameState = GameState.Playing;
    }
}
