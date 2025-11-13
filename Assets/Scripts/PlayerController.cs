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
    private float _torqueAmount = 50.0f;
    [SerializeField]
    float _baseSpeed = 15.0f;
    [SerializeField]
    float _boostSpeed = 40.0f;

    bool _canControlPlayer = true;

    float _previousRotation;
    float _totalRotation;

    ScoreManager _scoreManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        _surfaceEffector = FindFirstObjectByType<SurfaceEffector2D>();
        _scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_canControlPlayer)
        {
            RotatePlayer();
            BoostPlayer();
            CalculateFlips();
        }
    }

        void RotatePlayer()
    {
        _moveVector = moveAction.ReadValue<Vector2>();

        if (_moveVector.x < 0.0f)
        {
            playerRigidbody2D.AddTorque(_torqueAmount);
        }
        else if (_moveVector.x > 0.0f)
        {
            playerRigidbody2D.AddTorque(-_torqueAmount);
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

    void CalculateFlips()
    {
        float currentRotation = transform.rotation.eulerAngles.z;
        _totalRotation += Mathf.DeltaAngle(_previousRotation, currentRotation);
        _previousRotation = currentRotation;

        if(_totalRotation > 340 ||  _totalRotation < -340f)
        {
            _totalRotation = 0;
            _scoreManager.AddScore(100);
        }
    }

    public void DisableControls()
    {
        _canControlPlayer = false;
    }

    public void ActivatePowerup(PowerUpScriptableObject powerup)
    {
        if (powerup.GetPowerupType() == PowerUpScriptableObject._powerupTypes.speed)
        {
            _baseSpeed += powerup.GetValueChange();
            _boostSpeed += powerup.GetValueChange();
        }


        else if (powerup.GetPowerupType() == PowerUpScriptableObject._powerupTypes
                                                                    .torque)
        {
            _torqueAmount += powerup.GetValueChange();
        }
    }
    public void DeactivatePowerup(PowerUpScriptableObject powerup)
    {
        if (powerup.GetPowerupType() == PowerUpScriptableObject._powerupTypes.speed)
        {
            _baseSpeed -= powerup.GetValueChange();
            _boostSpeed -= powerup.GetValueChange();
        }


        else if (powerup.GetPowerupType() == PowerUpScriptableObject._powerupTypes
                                                                    .torque)
        {
            _torqueAmount -= powerup.GetValueChange();
        }
    }
}
