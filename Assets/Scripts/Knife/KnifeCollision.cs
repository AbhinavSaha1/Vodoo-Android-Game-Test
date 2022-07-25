using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class KnifeCollision : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (_gameManager.GameState == GameState.Playing)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                Debug.Log("Game over!");
                FindObjectOfType<AudioManager>().Play("Level Failed");
                _gameManager.GameState = GameState.Lose;
            }
            if (collision.gameObject.CompareTag("EndLevelCheckPoint"))
            {
                FindObjectOfType<AudioManager>().Play("Win");
                _gameManager.GameState = GameState.Win;
            }
        }
    }
}
