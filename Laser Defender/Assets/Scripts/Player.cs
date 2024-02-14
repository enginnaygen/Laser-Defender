using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 _playerInput;
    [SerializeField] float speedController;

    Vector2 _maxBound, _minBound;

    [SerializeField] float paddingTop, paddingBottom, paddingLeft, paddingRight;

    Shooter _shooter;

    //[SerializeField] AudioClip laserSFX;
    private void Awake()
    {
        _shooter = GetComponent<Shooter>();
    }
    private void Start()
    {
        InitBounds();
    }
    private void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        Vector2 delta = _playerInput* speedController*Time.deltaTime;

        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp((transform.position.x) + delta.x, _minBound.x + paddingLeft, _maxBound.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, _minBound.y + paddingBottom, _maxBound.y - paddingTop);
        transform.position = newPos;
        //transform.position += (delta.normalized) * Time.deltaTime * speedController;

    }

     void InitBounds()
    {
        Camera mainCam = Camera.main;
        _maxBound = mainCam.ViewportToWorldPoint(new Vector2(1f, 1f));
        _minBound = mainCam.ViewportToWorldPoint(new Vector2(0f, 0f));
    }

    void OnMove(InputValue value)
    {
        _playerInput = value.Get<Vector2>();

    }

    void OnFire(InputValue value)
    {
       if(_shooter != null)
        {
            //AudioSource.PlayClipAtPoint(laserSFX, Camera.main.transform.position);
            _shooter.isFiring = value.isPressed;
        }
    }

    
}
