using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBoxScript : MonoBehaviour
{
    public GameObject playerObject;

    private Movement moveScript;
    private healthSystem playerHealthSystem;
    private Rigidbody2D playerRb;
    private Vector2 attackDirection;

    public float hurtForceTime = 1f;
    public float hurtForceX = 10f;
    public float hurtForceY = 10f;

    private float hurtforceXTemp;
    private float hurtforceYTemp;

    private float hurtForceTimeCounter;

    public int damage = 10;

    private void Start()
    {
        playerHealthSystem = playerObject.GetComponent<healthSystem>();
        moveScript = playerObject.GetComponent<Movement>();
        playerRb = playerObject.GetComponent<Rigidbody2D>();

        hurtforceXTemp = hurtForceX;
        hurtforceYTemp = hurtForceY;
    }

    private void Update()
    {
        if (hurtForceTimeCounter > 0)
        {
            moveScript.canMove = false;
            hurtForceTimeCounter -= Time.deltaTime;
            playerRb.velocity = new Vector2(attackDirection.x * hurtforceXTemp, attackDirection.y * hurtforceYTemp);

            hurtforceXTemp -= Time.deltaTime;
            hurtforceYTemp -= Time.deltaTime;
        }
        else
        {
            moveScript.canMove = true;
            hurtforceXTemp = hurtForceX;
            hurtforceYTemp = hurtForceY;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealthSystem.TakeDamage(damage);

            attackDirection = transform.position - collision.transform.position;
            attackDirection.Normalize();
            attackDirection = -attackDirection;

            if (attackDirection.x > 0)
                attackDirection.x = 1;
            else if (attackDirection.x < 0)
                attackDirection.x = -1;

            hurtForceTimeCounter = hurtForceTime;
        }
    }
}
