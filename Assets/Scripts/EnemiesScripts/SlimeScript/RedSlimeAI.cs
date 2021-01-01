using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSlimeAI : MonoBehaviour
{
    private Animator anim;
    public GameObject PlayerObject;
    private Movement moveScript;
    private Rigidbody2D playerRb;

    public GameObject BoxObject;
    private Rigidbody2D BoxRb;

    public LayerMask playerLayer;
    [Range (1,5)]
    public float seePlayerRadius;
    private bool seePlayer;

    [Range(0, 2)]
    public float slimeAttackRange;
    public float timeBetweenSlimeAttacks;
    private float timeBetweenSlimeAttacks_Counter;
    public int AttackDamage;
    private bool isPlayerInAttackRange;
    private float timeBetweenGivingDamageToPlayer = 1f;
    private float timeBetweenGivingDamageToPlayer_Counter;

    private float hurtForceTime;
    private float hurtForceTime_Counter;
    private Vector2 attackDirection;
    private float hurtForceX;
    private float hurtForceY;

    private bool isBoxInRange;
    public LayerMask BoxLayer;
    private Vector2 boxFlyDirection;
    [Range(0, 3)]
    public float boxFlyTime;
    private float boxFlyTime_Counter;
    public float boxFlyForceX;
    public float boxFlyForcey;




    private void Start()
    {
        anim = GetComponent<Animator>();
        timeBetweenSlimeAttacks_Counter = timeBetweenSlimeAttacks;
        timeBetweenGivingDamageToPlayer_Counter = timeBetweenGivingDamageToPlayer;

        hurtForceTime = PlayerObject.GetComponent<HurtForceVariables>().hurtForceTime;
        hurtForceX = PlayerObject.GetComponent<HurtForceVariables>().hurtForceX;
        hurtForceY = PlayerObject.GetComponent<HurtForceVariables>().hurtForceY;

        moveScript = PlayerObject.GetComponent<Movement>();
        playerRb = PlayerObject.GetComponent<Rigidbody2D>();

        BoxRb = BoxObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        seePlayer = Physics2D.OverlapCircle(transform.position, seePlayerRadius, playerLayer);

        if (seePlayer && timeBetweenSlimeAttacks_Counter <= 0)
        {
            anim.SetBool("Attack", true);
            timeBetweenSlimeAttacks_Counter = timeBetweenSlimeAttacks;
        }
        else
        {
            anim.SetBool("Attack",false);
            timeBetweenSlimeAttacks_Counter -= Time.deltaTime;
        }

        if (hurtForceTime_Counter > 0)
        {
            moveScript.canMove = false;
            hurtForceTime_Counter -= Time.deltaTime;
            playerRb.velocity = new Vector2(attackDirection.x * hurtForceX, attackDirection.y * hurtForceY);
        }
        else
            moveScript.canMove = true;


        if (boxFlyTime_Counter > 0)
        {
            boxFlyTime_Counter -= Time.deltaTime;
            BoxRb.velocity = new Vector2(boxFlyDirection.x * boxFlyForceX, boxFlyDirection.y * boxFlyForcey);
        }



    }

    private void HurtForcePositionCalculate() // using from animation (RedSlime Attack anim)
    {
        // >>>>>>>>>>>>>>>>> Player Hurt Force <<<<<<<<<<<<<<<<<<<<<<
        isPlayerInAttackRange = Physics2D.OverlapCircle(transform.position, slimeAttackRange, playerLayer);
        if (isPlayerInAttackRange)
        {
            Debug.Log("Player in range");
            attackDirection = transform.position - PlayerObject.transform.position;
            attackDirection = -attackDirection;

            if (attackDirection.x > 0)          //These are setting hurt vectors
                attackDirection.x = 1;
            else if (attackDirection.x < 0)
                attackDirection.x = -1;

            attackDirection.y = 1;
            hurtForceTime_Counter = hurtForceTime;

            PlayerObject.GetComponent<healthSystem>().TakeDamage(AttackDamage);
            PlayerObject.GetComponent<HurtForceVariables>().inHurtForce = true;
        }

        // >>>>>>>>>>>>>>>>> Box Fly Force <<<<<<<<<<<<<<<<<<<<<<
        isBoxInRange = Physics2D.OverlapCircle(transform.position, slimeAttackRange, BoxLayer);
        if (isBoxInRange)
        {
            boxFlyDirection = transform.position - BoxObject.transform.position;
            boxFlyDirection = -boxFlyDirection;

            boxFlyDirection.y = 1;
            boxFlyTime_Counter = boxFlyTime;
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, seePlayerRadius);
        Gizmos.DrawWireSphere(transform.position, slimeAttackRange);
    }

}
