using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                _gameManager.GameState = GameState.Lose;
            }
            if (collision.gameObject.CompareTag("EndLevelCheckPoint"))
            {
                _gameManager.GameState = GameState.Win;
            }
        }
    }
}
