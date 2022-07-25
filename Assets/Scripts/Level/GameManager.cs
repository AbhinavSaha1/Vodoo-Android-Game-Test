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
    [SerializeField]
    private GameObject _winScreen;
    [SerializeField]
    public GameObject _loseScreen;
    [SerializeField]
    public GameObject _startMenu;
    [SerializeField]
    public GameObject _scoreText;
    [SerializeField]
    public GameObject _dashUI;

    void Start()
    {
        _levelRef = GameObject.FindObjectOfType<LevelDataHolder>();
        GameState = GameState.Start;
        _startMenu.SetActive(true);
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
        _dashUI.SetActive(false);
        _winScreen.SetActive(true);
    }
    public void  YouLose()
    {
        _dashUI.SetActive(false);
        _loseScreen.SetActive(true);
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
        SceneManager.LoadScene(0);
    }
    IEnumerator Setup()
    {
        yield return new WaitForSeconds(0.15f);
        _startMenu.SetActive(false);
        _scoreText.SetActive(true);
        _dashUI.SetActive(true);
        GameState = GameState.Playing;
    }
}
