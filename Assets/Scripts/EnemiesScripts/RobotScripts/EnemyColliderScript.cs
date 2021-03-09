using UnityEngine;

public class EnemyColliderScript : MonoBehaviour
{
    public GameObject playerObject;

    private Movement moveScript;
    private healthSystem playerHealthSystem;
    private Rigidbody2D playerRb;
    private Vector2 attackDirection;

    private float hurtForceTime;
    private float hurtForceX;
    private float hurtForceY;

    private float hurtForceTimeCounter;

    private int touchDamage;


    private void Start()
    {
        playerHealthSystem = playerObject.GetComponent<healthSystem>();
        moveScript = playerObject.GetComponent<Movement>();
        playerRb = playerObject.GetComponent<Rigidbody2D>();

        hurtForceTime = playerObject.GetComponent<HurtForceVariables>().hurtForceTime;
        hurtForceX = playerObject.GetComponent<HurtForceVariables>().hurtForceX;
        hurtForceY = playerObject.GetComponent<HurtForceVariables>().hurtForceY;
        touchDamage = playerObject.GetComponent<HurtForceVariables>().touchDamage;

    }

    private void Update()
    {
        if (hurtForceTimeCounter > 0)
        {
            moveScript.canMove = false;
            hurtForceTimeCounter -= Time.deltaTime;
            playerRb.velocity = new Vector2(attackDirection.x * hurtForceX, attackDirection.y * hurtForceY);
        }
        else
            moveScript.canMove = true;

        if (gameObject.tag == "Spike")
        {
            touchDamage = playerHealthSystem.maxHealt;
        }

        if (gameObject.tag != "Spike")
        {
            if (GetComponent<EnemySlimeHealthSystem>().enemyisDead)
            {
                Destroy(this);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (!playerHealthSystem.touchedToEnemy) // not touched or touchTime is still counting
            {
                playerHealthSystem.touchedToEnemy = true;

                playerHealthSystem.TakeDamage(touchDamage);

                attackDirection = transform.position - collision.transform.position;
                attackDirection = -attackDirection;

                if (attackDirection.x > 0)          //These are setting hurt vectors
                    attackDirection.x = 1;
                else if (attackDirection.x < 0)
                    attackDirection.x = -1;

                attackDirection.y = 1;
                hurtForceTimeCounter = hurtForceTime;


                playerObject.GetComponent<HurtForceVariables>().inHurtForce = true;
            }
        }
    }
}
