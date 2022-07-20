using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public float _upwardsVelocity = 1f;
    public float _forwardVelocity = 1f;
    [SerializeField]
    //private Animator _animator;
    private Rigidbody rb;
    private GameManager _gameManager;
    public float _torque = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
       // _animator = GetComponent<Animator>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if(_gameManager.GameState == GameState.Playing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector3.up * _upwardsVelocity;
                //rb.velocity = Vector3.right * _forwardVelocity;
                rb.AddForce(Vector3.forward * _forwardVelocity * Time.deltaTime, ForceMode.Impulse);
                //if(_animator.GetBool("Rotate") == false)
                //{
                //    _animator.SetBool("Rotate", true);

                //}
                rb.AddTorque(new Vector3(_torque, 0, 0), ForceMode.Impulse);
            }
            Debug.Log(transform.InverseTransformDirection(rb.angularVelocity).x);

            if(transform.InverseTransformDirection(rb.angularVelocity).x > 0.02)
            {
                rb.AddTorque(new Vector3(-(_torque/8), 0, 0), ForceMode.Impulse);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.angularVelocity = Vector3.zero;
            }
            //if(Input.GetMouseButtonUp(0))
            //{
            //    _animator.SetBool("Rotate", false);
            //}
        }

    }
}
