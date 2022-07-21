using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutCollision : MonoBehaviour
{
    [SerializeField]
    private int _score = 0;
    [SerializeField]
    private Rigidbody _rb;
    public Text ScoreText;
    public Text WinScoreText;
    private GameManager _gameManager;
    

    private void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_gameManager.GameState == GameState.Playing)
        {
            if (other.gameObject.CompareTag("Sliceable"))
            {
                CubeCut.Cut(other.transform, transform.position);
                _rb.angularVelocity = Vector3.zero;
                UpdateScore();
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
