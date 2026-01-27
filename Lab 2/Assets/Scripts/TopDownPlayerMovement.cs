using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownPlayer : MonoBehaviour
{
    public InputAction moveInput;
    private Vector2 movementDirection = Vector2.zero;
    public float speed;

    private void Awake()
    {
        moveInput.Enable();
        moveInput.performed += GetMoveVector;
        moveInput.canceled += GetMoveVector;
    }

    public void GetMoveVector(InputAction.CallbackContext c)
    {
        movementDirection = c.ReadValue<Vector2>();
    }

    private void Update()
    {
        transform.position += new Vector3(movementDirection.x, movementDirection.y, 0) * speed * Time.deltaTime;
    }
}
