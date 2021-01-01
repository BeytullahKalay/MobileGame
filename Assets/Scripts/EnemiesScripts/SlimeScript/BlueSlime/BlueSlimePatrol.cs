using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSlimePatrol : MonoBehaviour
{

    Rigidbody2D rb;
    Animator anim;

    public float jumpForce;
    public Transform groundCheck;
    [Range(0, 1)]
    public float checkRadius;
    [HideInInspector] public bool isGrounded;
    public LayerMask whatIsGround;
    public float timeBetweenJumps = 1f;
    private float timeBetweenJumps_Counter;
    public float speed = 3f;

    public Transform RightWallCheckObject;
    public Transform LeftWallCheckObject;
    public LayerMask whatIsWall;
    private bool rightWallCheck;
    private bool leftWallCheck;
    [Range (0,1)]
    public float wallCheckRadius;
    private int direction = 1;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        timeBetweenJumps_Counter = timeBetweenJumps;

    }


    private void Update()
    {

        if (!GetComponentInChildren<EnemySlimeHealthSystem>().enemyisDead)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

            if (isGrounded)
            {
                anim.SetBool("isGrounded", true);
                timeBetweenJumps_Counter -= Time.deltaTime;

                if (timeBetweenJumps_Counter <= 0)
                {
                    anim.SetTrigger("Jump");
                    rb.velocity = Vector2.up * jumpForce;
                    timeBetweenJumps_Counter = timeBetweenJumps;
                }
            }
            else
                anim.SetBool("isGrounded", false);



            rightWallCheck = Physics2D.OverlapCircle(RightWallCheckObject.position, wallCheckRadius, whatIsWall);
            leftWallCheck = Physics2D.OverlapCircle(LeftWallCheckObject.position, wallCheckRadius, whatIsWall);


            if (rightWallCheck)
                direction = -1;
            if (leftWallCheck)
                direction = 1;
            if (rightWallCheck && leftWallCheck)
                direction = 0;


            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
                rb.velocity = new Vector2(direction * speed, rb.velocity.y);
            

        }
        else
            GameObject.Find("BlueSlimeCollider").layer = LayerMask.NameToLayer("Died");
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        Gizmos.DrawWireSphere(RightWallCheckObject.position, wallCheckRadius);
        Gizmos.DrawWireSphere(LeftWallCheckObject.position, wallCheckRadius);
    }

}
