using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Knife : MonoBehaviour
{
    [SerializeField]
    private float _dashForce = 2.5f;
    [SerializeField]
    private float _dragDistance;
    [SerializeField]
    private float _dashRate;
    [SerializeField]
    private float _gravityODuration;
    [SerializeField]
    private GameObject _dashUI;
    private float _dashCooldown;
    private Rigidbody rb;
    private GameManager _gameManager;
    private Vector3 _firstTouchPos;
    private Vector3 _finalTouchPos;
    public float _upwardsVelocity = 1f;
    public float _forwardVelocity = 1f;
    public float _torque = 1f;

    void Start()
    {
        _dragDistance = Screen.height * 15 / 100;
        rb = GetComponent<Rigidbody>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (_gameManager.GameState == GameState.Playing || _gameManager.GameState == GameState.Start)
        {
            AndroidInput();
            if (SystemInfo.deviceType == DeviceType.Handheld)
            {
                //AndroidInput();
            }
            else
            {
                //Debug.Log("You are on Windows");
                WindowsInput();
            }
            //Stopping the knife from unlimited rotation speed when touch is spammed
            KnifeAngularDrag();
            //Debug.Log(transform.InverseTransformDirection(rb.angularVelocity).x);
        }


    }

    private void WindowsInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            KnifeMovement();
        }

        //Dash test
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(KnifeDash());
        }
    }

    private void AndroidInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                _firstTouchPos = touch.position;
                _finalTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                _finalTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                _finalTouchPos = touch.position;
                if (Mathf.Abs(_finalTouchPos.x - _firstTouchPos.x) > _dragDistance || Mathf.Abs(_finalTouchPos.y - _firstTouchPos.y) > _dragDistance)
                {
                    if (Mathf.Abs(_finalTouchPos.x - _firstTouchPos.x) > Mathf.Abs(_finalTouchPos.y - _firstTouchPos.y))
                    {
                        if (_finalTouchPos.x > _firstTouchPos.x)
                        {
                            //right swipe
                            StartCoroutine(KnifeDash());
                        }
                    }
                }
                else
                {
                    //tap
                    KnifeMovement();
                }
            }
        }
    }

    private IEnumerator KnifeDash()
    {
        if (Time.time > _dashRate + _dashCooldown)
        {
            _dashUI.SetActive(false);
            rb.angularVelocity = Vector3.zero;
            rb.useGravity = false;
            rb.AddForce(Vector3.forward * _forwardVelocity * _dashForce * Time.deltaTime, ForceMode.Impulse);
            _dashCooldown = Time.time;
            yield return new WaitForSeconds(_gravityODuration);
            rb.useGravity = true;
            yield return new WaitForSeconds(_dashRate - _gravityODuration);
            _dashUI.SetActive(true);
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
        if (transform.InverseTransformDirection(rb.angularVelocity).x > 0.011)
        {
            rb.AddTorque(new Vector3(-(_torque / 8), 0, 0), ForceMode.Impulse);
        }
    }
   
}
