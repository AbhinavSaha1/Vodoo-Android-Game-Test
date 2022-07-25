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
    private AudioManager _audioManager;
    

    private void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_gameManager.GameState == GameState.Playing)
        {
            if (other.gameObject.CompareTag("Sliceable"))
            {
                _audioManager.Play("Slice");
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
