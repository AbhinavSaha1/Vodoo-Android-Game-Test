using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField]
    private float _minSwipeDistance;
    [SerializeField]
    private float _dashRate;
    private float _lastDash;
    private Rigidbody rb;
    private GameManager _gameManager;
    private Vector3 _firstTouchPos;
    private Vector3 _finalTouchPos;
    private float _swipeAngle;
    public float _upwardsVelocity = 1f;
    public float _forwardVelocity = 1f;
    public float _torque = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if(_gameManager.GameState == GameState.Playing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                KnifeMovement();
                _firstTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            if(Input.GetMouseButtonUp(0))
            {
                _finalTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float swipeDist = Mathf.Abs(_finalTouchPos.x - _firstTouchPos.x);
                //Debug.Log(swipeDist);
                //CalculateAngle();
            }
            //Debug.Log(transform.InverseTransformDirection(rb.angularVelocity).x);

            //Stopping the knife from unlimited rotation speed when touch is spammed
            KnifeAngularDrag();
            //test
            if (Input.GetKeyDown(KeyCode.Space))
            {
                KnifeDash();
            }

            //if (swipeDist > _minSwipeDistance)
            //{

            //    Debug.Log("Swiped");
            //}
        }

    }

    private void KnifeDash()
    {
        if (Time.time > _dashRate + _lastDash)
        {
            rb.angularVelocity = Vector3.zero;
            rb.AddForce(Vector3.forward * _forwardVelocity * 2.5f * Time.deltaTime, ForceMode.Impulse);
            _lastDash = Time.time;
        }
    }

    private void KnifeMovement()
    {
        rb.velocity = Vector3.up * _upwardsVelocity;
        rb.AddForce(Vector3.forward * _forwardVelocity * Time.deltaTime, ForceMode.Impulse);
        rb.AddTorque(new Vector3(_torque, 0, 0), ForceMode.Impulse);
    }
    private void KnifeAngularDrag()
    {
        if (transform.InverseTransformDirection(rb.angularVelocity).x > 0.02)
        {
            rb.AddTorque(new Vector3(-(_torque / 8), 0, 0), ForceMode.Impulse);
        }
    }
    private void CalculateAngle()
    {
        _swipeAngle = Mathf.Atan2(_finalTouchPos.y - _firstTouchPos.y, _finalTouchPos.x - _firstTouchPos.x) * 180/Mathf.PI;
        Debug.Log(_swipeAngle);
    }

    private void SwipeDistanceCheckMet()
    {
        float swipeDist = Mathf.Abs(_finalTouchPos.z - _firstTouchPos.z);
        Debug.Log(swipeDist);
        //return swipeDist > _minSwipeDistance;
    }
}
