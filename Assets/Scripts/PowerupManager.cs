using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField]
    PowerUpScriptableObject _powerup;
    SpriteRenderer _spriteRenderer;
    PlayerController _playerController;
    float _timeLeft;

    private void Start()
    {
        _playerController = FindFirstObjectByType<PlayerController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _timeLeft = _powerup.GetTime();
    }

    private void Update()
    {
        CountDownTimer();
    }

    private void CountDownTimer()
    {
        if (_spriteRenderer.enabled == false && _timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            if (_timeLeft <= 0)
            {
                _playerController.DeactivatePowerup(_powerup);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if (collision.gameObject.layer == layerIndex && _spriteRenderer.enabled)
        {
            _playerController.ActivatePowerup(_powerup);
            _spriteRenderer.enabled = false;
        }
    }

}
