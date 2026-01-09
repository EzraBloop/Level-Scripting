using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovemt : MonoBehaviour
{
   
    // read the input from the player 
    // store the movement direction 
    // apply the movement to the player 

    public InputAction moveAction;
    private Vector3 moveDirection = Vector3.zero;
    public float moveSpeed = 1.0f;

    private void Start()
    {
        moveAction.Enable();
        moveAction.performed += GetMoveVector; // performed auto passes the call back context 
        moveAction.canceled += GetMoveVector; 
    }

    public void GetMoveVector(InputAction.CallbackContext context) // get reference to what button was pressed 
    {
        var tmp = context.ReadValue<Vector2>();
        moveDirection = new Vector3(tmp.x, 0, tmp.y);
    }

    private void FixedUpdate()
    {
        transform.position += moveDirection * moveSpeed * Time.fixedDeltaTime; 
    }

}
