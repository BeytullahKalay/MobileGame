using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    Rigidbody2D rb;
    public int Damage = 100;
    public float velocityLimitForGivingDamage = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "SlimeEnemy")
        {
            if (rb.velocity.x > velocityLimitForGivingDamage || rb.velocity.x < -velocityLimitForGivingDamage
                || rb.velocity.y > velocityLimitForGivingDamage || rb.velocity.y < -velocityLimitForGivingDamage)
            {
                collision.gameObject.GetComponentInChildren<EnemySlimeHealthSystem>().TakeDamage(Damage);
            }
        }

        if (collision.collider.tag == "Player")
            collision.transform.parent = this.gameObject.transform;

        if (collision.collider.tag == "killZone")
        {
            Destroy(gameObject);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
            collision.transform.parent = null;
    }
}
