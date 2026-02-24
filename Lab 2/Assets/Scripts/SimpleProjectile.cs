using System.Collections;
using UnityEngine;

public class SimpleProjectile : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float duration;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void InstantiateProjectile(Vector2 direction)
    {
        rb.linearVelocity = direction * speed;
        StartCoroutine(ProjectileTimer());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<TopDownPlayerMovement>().TakeDamage(2);
            Destroy(gameObject);
        }
    }

    public IEnumerator ProjectileTimer()
        {
            yield return new WaitForSeconds(duration);
            yield return new WaitForEndOfFrame();
            Destroy(gameObject);
        }
}
