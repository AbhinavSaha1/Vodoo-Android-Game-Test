using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeHandleCollision : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _knifeRb;
    private GameManager _gameManager;
    private KnifeController _knife;
    private AudioManager _audioManager;

    private void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _audioManager = FindObjectOfType<AudioManager>();
        _knife = GameObject.FindObjectOfType<KnifeController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_gameManager.GameState == GameState.Playing)
        {
            if (other.gameObject.CompareTag("Sliceable"))
            {
                //Debug.Log("Entered trigger");
                _audioManager.Play("Handle");
                _knifeRb.velocity = Vector3.up * _knife._upwardsVelocity;
                _knifeRb.AddForce(Vector3.forward * - (_knife._forwardVelocity/10) * Time.deltaTime, ForceMode.Impulse);
                _knifeRb.AddTorque(new Vector3(- _knife._torque, 0, 0), ForceMode.Impulse);
            }
        }
    }
}
