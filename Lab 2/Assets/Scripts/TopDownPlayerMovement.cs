using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TopDownPlayerMovement : MonoBehaviour
{
    public InputAction moveInput;
    public InputAction attack;
    public InputAction interact;
    private Vector2 movementDirection = Vector2.zero;
    public int hp = 10;
    public float moveSpeed;
    public event Action<Vector2> OnMove;
    private void Awake()
    {
        moveInput.Enable();
        moveInput.performed += GetMoveVector;
        moveInput.canceled += GetMoveVector;

        attack.Enable();
        attack.performed += Attack;

        interact.Enable();
        interact.performed += Interact;
    }

    public void GetMoveVector(InputAction.CallbackContext c)
    {
        movementDirection = c.ReadValue<Vector2>();
        OnMove?.Invoke(movementDirection);

    }

    private void Update()
    {
        transform.position += new Vector3(movementDirection.x, movementDirection.y, 0) * moveSpeed * Time.deltaTime;

        if(hp <= 0)
        {
            Die();
        }
    }

    public void Attack(InputAction.CallbackContext c)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 4f);

        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject.CompareTag("Enemy"))
            {
                hit.GetComponent<Enemy>().TakeDamage(2);
            }
        }
    }

    public void Interact(InputAction.CallbackContext c)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 4f);

        foreach (Collider2D hit in hits)
        {
            Debug.Log(hit);
            if (hit.GetComponent<InteractableItem>() != null) 
            {
                hit.GetComponent<InteractableItem>().Interact();
            }
        }
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
    }

    public void Heal()
    {
        hp = 10;
    }


    public void Die()
    {
        SceneManager.LoadScene("MenuScene");
    }

}