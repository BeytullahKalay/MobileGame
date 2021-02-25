using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Movement Definations
    public float speed;
    Rigidbody2D rb;
    [HideInInspector] public float input;

    [Range(0, 1)]
    public float fHorizontalVelocityDamping;

    public Joystick joystick;
    public float joystickSensivitiy = 0.2f;
    [HideInInspector]public bool canMove = true;
    [HideInInspector] public bool facingRight = true;
    private bool canFlip = true;
    #endregion

    #region Jump Definations
    public float jumpForce;
    public Transform groundCheck;
    public float checkRadius;
    [HideInInspector] public bool isGrounded;
    public LayerMask whatIsGround;
    #endregion

    #region Dash Defiantions

    private float dashTimeCounter;
    private float lastDashTime = -100f;
    private float dashDirection;
    [HideInInspector]public bool isDashing;
    public float totalDashTime = 0.1f;
    public float dashSpeed;
    public float dashSensitivity = 60;
    public float dashCoolDown;
    bool dashStarted = false;
    #endregion

    #region Better Jump Definations
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    #endregion

    #region Jump Issues

    public float JumpSensitivity;
    private bool stillJump;
    public float totalJumpInputTime = 0.2f;
    public float totalFallJumpInputTime = 0.2f;
    private float fallJumpInputTimer;
    private float JumpInputTimer;

    #endregion

    #region CantControlTime_AfterHurt
    [HideInInspector] public bool inHurtForce = false;
    #endregion

    #region Spawnin Box Definations
    public float spawnBoxTime;
    public float spawnBoxSensitivity;
    public GameObject myBox;
    public Transform SpawnBox_Position;
    public float DestroyBox_Time;
    [HideInInspector]
    public float spawnBoxTime_Counter;
    private GameObject canDestroyableObject;
    private Queue<GameObject> boxes = new Queue<GameObject>();
    #endregion

    #region Dialogue System Definations
    private NPC_Controller npc;
    private bool canTalkWithNPC = true;
    #endregion

    #region Box Ability Accesibility
    private GameMaster _gm;
    #endregion

    private PlayerCombat playerCombatScript;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCombatScript = GetComponent<PlayerCombat>();
        _gm = FindObjectOfType<GameMaster>();
        dashTimeCounter = totalDashTime;
    }

    void Update()
    {
        JumpInputTimer -= Time.deltaTime;
        fallJumpInputTimer -= Time.deltaTime;
        spawnBoxTime_Counter -= Time.deltaTime;

        CheckDash();

        Check_inHurtForce();

        Inputs_And_Movements();

        if (!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Dash"))
            dashStarted = false;

    }

    void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
        facingRight = !facingRight;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }

    private void AttemToDash()
    {
        if (Time.time >= lastDashTime + dashCoolDown)
        {
            isDashing = true;
            dashTimeCounter = totalDashTime;
            lastDashTime = Time.time;

            playerCombatScript.comingDashInput = true; //checking dash input for attack
        }
    }

    private void CheckDash()
    {
        if (isDashing)
        {
            lastDashTime = Time.time;
            if (dashDirection > 0 && facingRight == false)
                Flip();
            else if (dashDirection < 0 && facingRight == true)
                Flip();


            if (dashTimeCounter > 0)
            {
                canMove = false;
                canFlip = false;
                rb.velocity = new Vector2(dashSpeed * dashDirection, 0);
                dashTimeCounter -= Time.deltaTime;
            }

            GameObject.Find("PlayerCollider").layer = LayerMask.NameToLayer("Dashing"); //Changing Layer to "Dashing" while dashing
        }

        if (dashTimeCounter <= 0)
        {
            isDashing = false;
            canMove = true;
            canFlip = true;

            GameObject.Find("PlayerCollider").layer = LayerMask.NameToLayer("Player"); //Changing Layer back to "Player" after dash 
        }
    }


    private void Check_inHurtForce()
    {
        inHurtForce = GetComponent<HurtForceVariables>().inHurtForce;
    }


    private void Inputs_And_Movements()
    {

        #region Jump, Dash and Box Input

        if (Input.touchCount > 0)
        {
            float[] x0 = new float[Input.touchCount];
            float[] x1 = new float[Input.touchCount];
            float[] y0 = new float[Input.touchCount];
            float[] y1 = new float[Input.touchCount];

            Touch[] touch = new Touch[Input.touchCount];
            Vector2[] touch_pos = new Vector2[Input.touchCount];

            for (int i = 0; i < Input.touchCount; i++)
            {
                touch[i] = Input.GetTouch(i);
                touch_pos[i] = Camera.main.ScreenToViewportPoint(touch[i].position);

                x0[i] = x1[i] = y0[i] = y1[i] = 0;


                if (touch_pos[i].x > 0.5f && !inDialogue())
                {

                    #region Jump Input
                    // >>>>>>>>>>>>>>>>>>   JUMP    <<<<<<<<<<<<<<<<<<<<<<<<<<<

                    if (touch[i].deltaPosition.y > JumpSensitivity)                   // Jump input
                    {
                        JumpInputTimer = totalJumpInputTime;
                        stillJump = true;

                        playerCombatScript.comingJumpInput = true;                    // checking run input for attack touch
                    }

                    if (touch[i].phase == TouchPhase.Stationary)
                        stillJump = true;

                    #endregion

                    #region Dash Input & Dash Movement Call
                    // >>>>>>>>>>>>>>>>>>   DASH    <<<<<<<<<<<<<<<<<<<<<<<<<<<

                    if (dashDirection == 0 && !playerCombatScript.playerStillAttackAnim)   //If dash input not entered yet and player not in attack animation
                    {
                        if (touch[i].deltaPosition.x > dashSensitivity)
                            dashDirection = 1;
                        else if (touch[i].deltaPosition.x < -dashSensitivity)
                            dashDirection = -1;
                        else
                            dashDirection = 0;
                    }
                    else
                    {
                        if (dashTimeCounter <= 0)                                //If dash time is end
                        {
                            dashDirection = 0;
                            dashTimeCounter = totalDashTime;
                            rb.velocity = Vector2.zero;
                        }
                        else
                        {
                            dashTimeCounter -= Time.deltaTime;

                            if (dashDirection == 1)
                                AttemToDash();
                            else if (dashDirection == -1)
                                AttemToDash();
                        }
                    }

                    #endregion

                    #region BOX SPAWN
                    // >>>>>>>>>>>>>>>>>>   BOX SPAWN    <<<<<<<<<<<<<<<<<<<<<<<<<<<
                    if (touch[i].deltaPosition.y < -spawnBoxSensitivity && _gm.GetComponent<AbilityHolder>().BoxAbilityActive())
                    {
                        if (spawnBoxTime_Counter <= 0)
                        {
                            canDestroyableObject = Instantiate(myBox, SpawnBox_Position.position, SpawnBox_Position.rotation);
                            boxes.Enqueue(canDestroyableObject);
                            spawnBoxTime_Counter = spawnBoxTime;
                            FindObjectOfType<AudioManager>().Play("SpawnBox");
                            Invoke("DestroyLastBox", DestroyBox_Time);
                        }

                        playerCombatScript.comingSpawnBoxInput = true;
                    }
                    #endregion

                }
                if (touch[i].phase == TouchPhase.Ended)
                    stillJump = false;
                
            }

        }
        #endregion

        #region Movement

        if (canMove && !isDashing && !inHurtForce && !inDialogue())
        {

            if (joystick.Horizontal >= joystickSensivitiy)
            {
                input = 1;
                rb.velocity = new Vector2(input * speed, rb.velocity.y);
            }
            else if (joystick.Horizontal <= -joystickSensivitiy)
            {
                input = -1;
                rb.velocity = new Vector2(input * speed, rb.velocity.y);
            }
            else
            {
                input = 0;
                float fHorizontalVelocity = rb.velocity.x;
                fHorizontalVelocity *= Mathf.Pow(1f - fHorizontalVelocityDamping, Time.deltaTime * 10f);
                rb.velocity = new Vector2(fHorizontalVelocity, rb.velocity.y);
            }

        }
        #endregion

        #region Flipping
        if (canFlip)
        {
            if (input > 0 && facingRight == false)
                Flip();
            else if (input < 0 && facingRight == true)
                Flip();
        }

        #endregion

        #region Jumping

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (isGrounded)
            fallJumpInputTimer = totalFallJumpInputTime;


        if ((fallJumpInputTimer > 0) && (JumpInputTimer > 0) && !playerCombatScript.playerStillAttackAnim)
        {
            rb.velocity = Vector2.up * jumpForce;
            JumpInputTimer = 0;
            fallJumpInputTimer = 0;
        }
        #endregion

        #region Better Jump

        if (rb.velocity.y < 0) // if falling
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        else if (rb.velocity.y > 0 && !stillJump)
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        #endregion

    }

    private void DestroyLastBox()
    {
        Destroy(boxes.Dequeue());
    }


    public bool inDialogue()
    {
        if (npc != null)
        {
            return npc.dialogueActive();
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            npc = collision.gameObject.GetComponent<NPC_Controller>();
            if (Input.GetMouseButtonDown(0) && canTalkWithNPC)
            {
                npc.ActivateDialogue();
                canTalkWithNPC = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        npc = null;
        canTalkWithNPC = true;
    }

    public void playJumpSound()
    {
        FindObjectOfType<AudioManager>().Play("JumpSound");
    }

    public void playDashSound()
    {
        if (!dashStarted)
        {
            FindObjectOfType<AudioManager>().Play("DashSound");
            dashStarted = true;
        }
    }


}
