using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutCollision : MonoBehaviour
{
    [SerializeField]
    private int _score = 0;
    public Text ScoreText;
    public Text WinScoreText;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(_gameManager.GameState == GameState.Playing)
        {
            
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_gameManager.GameState == GameState.Playing)
        {
            if (other.gameObject.CompareTag("Sliceable"))
            {
                CubeCut.Cut(other.transform, transform.position);
                UpdateScore();
            }
            if (other.gameObject.CompareTag("Obstacle"))
            {
                Debug.Log("Game over!");
                _gameManager.GameState = GameState.Lose;
            }
            if (other.gameObject.CompareTag("EndLevelCheckPoint"))
            {
                _gameManager.GameState = GameState.Win;
            }
        }
    }
    public void UpdateScore()
    {
        _score++;
        ScoreText.text = "Score: " + _score.ToString();
        WinScoreText.text = ScoreText.text;
    }
}
