using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputAction moveAction;
    Rigidbody2D playerRigidbody2D;
    [SerializeField]
    private float torqueAmount = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVector = moveAction.ReadValue<Vector2>();

        if (moveVector.x < 0.0f)
        {
            playerRigidbody2D.AddTorque(torqueAmount);
        }
        else if (moveVector.x > 0.0f)
        {
            playerRigidbody2D.AddTorque(-torqueAmount);
        }
    }
}
