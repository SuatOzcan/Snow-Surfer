using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField]
    PowerUpScriptableObject _powerup;

    PlayerController _playerController;

    private void Start()
    {
        _playerController = FindFirstObjectByType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if (collision.gameObject.layer == layerIndex)
        {
            _playerController.ActivatePowerup(_powerup);
        }
    }
}
