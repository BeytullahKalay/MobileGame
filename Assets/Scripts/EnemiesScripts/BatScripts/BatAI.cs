using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAI : MonoBehaviour
{
    public Transform playerPosition;
    public float speed;
    private Animator anim;
    private Bat_HealthSystem bat_HealthSystem;
    private BatTriggerAreaScript triggerAreaScript;


    private void Start()
    {
        anim = GetComponent<Animator>();
        bat_HealthSystem = GetComponentInChildren<Bat_HealthSystem>();
        triggerAreaScript = GetComponentInChildren<BatTriggerAreaScript>();
    }

    private void Update()
    {
        if (triggerAreaScript.enemyInRange && !bat_HealthSystem.isDead)
        {
            anim.SetBool("playerDetected", true);
            //play idle to fly animation then go towards player
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Fly"))
                transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
        }
    }
}
