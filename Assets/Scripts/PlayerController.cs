using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputAction moveAction;
    Rigidbody2D playerRigidbody2D;
    SurfaceEffector2D _surfaceEffector;
    Vector2 _moveVector;

    [SerializeField]
    private float torqueAmount = 50.0f;
    [SerializeField]
    float _baseSpeed = 15.0f;
    [SerializeField]
    float _boostSpeed = 40.0f;

    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        _surfaceEffector = FindFirstObjectByType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        BoostPlayer();
    }

    void RotatePlayer()
    {
        _moveVector = moveAction.ReadValue<Vector2>();

        if (_moveVector.x < 0.0f)
        {
            playerRigidbody2D.AddTorque(torqueAmount);
        }
        else if (_moveVector.x > 0.0f)
        {
            playerRigidbody2D.AddTorque(-torqueAmount);
        }
    }

    void BoostPlayer()
    {
        if(_moveVector.y > 0)
        {
            _surfaceEffector.speed = _boostSpeed;
        }
        else if( _moveVector.y <= 0)
        {
            _surfaceEffector.speed = _baseSpeed;
        }
    }
}
