using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public string enemyName;

    public int HP;
    public int ATK;
    public int DEF;
    public int speed;

    public float attackDelay;

    public CircleOverlap sightline;
    public CircleOverlap attackRange;

    public Vector2 playerPosition;

    private Coroutine attackCoroutine;

    private void Awake()
    {
        sightline.OnOverlap += SetPlayerPosition;
        attackRange.OnOverlap += SetPlayerPosition;
    }

    public void SetPlayerPosition(Vector2 pos)
    {
        playerPosition = pos;
    }
    public abstract void Patrol();

    public abstract void Attack();

    public abstract void TakeDamage(float dmg);

    public abstract void Die();

    public abstract void Pursue();


    private void Update()
    {
        if(sightline.CircleOverlapCheck())
        {
            Pursue();
        }

        if(attackRange.CircleOverlapCheck())
        {
            StartAttackCoroutine();
        }
        else
        {
            StopAllCoroutines();
        }
    }

    public void StartAttackCoroutine()
    {
        if(attackCoroutine == null) attackCoroutine = StartCoroutine(AttackCoroutine());
    }

    public IEnumerator AttackCoroutine()
    {
        while (true)
        {
            Attack();
            yield return new WaitForSeconds(attackDelay);
        }
        yield return null;
    }
}
