using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBallMonster_Patroll : MonoBehaviour
{

    private EyeBall_TriggerArea triggerArea_Script;
    private Rigidbody2D rb;
    private EyeBall_HealthSystem healthSystem;


    public float flipTime = 4f;
    private float flipTime_Counter;
    private bool facingRight = true;
    public float rollForce = 10f;
    public float rollTime = 3f;
    [HideInInspector] public float rollTime_Counter;

    private void Start()
    {
        triggerArea_Script = GetComponentInChildren<EyeBall_TriggerArea>();
        rb = GetComponent<Rigidbody2D>();
        healthSystem = GetComponentInChildren<EyeBall_HealthSystem>();
        flipTime_Counter = flipTime;
    }

    private void Update()
    {
        if (!healthSystem.enemyisDead)
        {

            if (!triggerArea_Script.inTriggerArea && rollTime_Counter > 0)
            {
                rb.AddForce(transform.right * rollForce);
                rollTime_Counter -= Time.deltaTime;
            }
            else if (!triggerArea_Script.inTriggerArea && rollTime_Counter <= 0)
            {
                flipTime_Counter -= Time.deltaTime;
                if (flipTime_Counter <= 0)
                {
                    Flip();
                    flipTime_Counter = flipTime;
                }
            }
            else
            {
                rollTime_Counter = rollTime;
                rb.AddForce(transform.right * rollForce);
            }
        }
        else
            rb.velocity = new Vector2(0,0);
    }

    private void Flip()
    {
        if (!facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            facingRight = true;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            facingRight = false;
        }
    }

}
