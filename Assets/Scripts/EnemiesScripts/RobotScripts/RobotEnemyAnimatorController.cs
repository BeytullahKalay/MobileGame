using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotEnemyAnimatorController : MonoBehaviour
{
    private Animator anim;
    private RobotPatrol patrolScript;
    private EnemyRobotHealthSystem healthSystem;

    private void Start()
    {
        patrolScript = GetComponentInParent<RobotPatrol>();
        anim = GetComponentInParent<Animator>();
        healthSystem = GetComponent<EnemyRobotHealthSystem>();
    }

    private void Update()
    {
        if (patrolScript.canAttack)
            anim.SetTrigger("Attack");

        if (patrolScript.canRun)
            anim.SetBool("canRun",true);
        else
            anim.SetBool("canRun",false);

        if (healthSystem.enemyisDead)
            anim.SetBool("Death", true);
    }

    public void setHurtTrigger()
    {
        anim.SetTrigger("Hurt");
    }
}
