using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private PlayerAnimatorController animatiorController;


    public Transform AttackPoint;
    public LayerMask enemyLayers;

    private float attackInputTimeCounter;

    public float attackRange = .5f;
    public float attacInputTime = .25f;

    private bool canAttack = false;
    private bool attackCheck;

    public int AttackDamage = 1;


    [HideInInspector] public bool comingDashInput;
    [HideInInspector] public bool comingJumpInput;
    [HideInInspector] public bool comingSpawnBoxInput;
    [HideInInspector] public bool playerStillAttackAnim;

    void Start()
    {
        animatiorController = GetComponent<PlayerAnimatorController>();

    }

    void Update()
    {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack1")
        || GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
            playerStillAttackAnim = true;
        else
            playerStillAttackAnim = false;

        AttackCheck();
    }

    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }

    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);

        //Damage Them
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.tag == "SlimeEnemy")
            {
                enemy.GetComponentInChildren<EnemySlimeHealthSystem>().TakeDamage(AttackDamage);
                FindObjectOfType<AudioManager>().Play("enemyHit");
            }

            if (enemy.tag == "RobotEnemy")
            {
                enemy.GetComponent<EnemyRobotHealthSystem>().TakeDamage(AttackDamage);
                FindObjectOfType<AudioManager>().Play("enemyHit");
            }

            if (enemy.tag == "EyeBallMonster")
            {
                enemy.GetComponentInChildren<EyeBall_HealthSystem>().TakeDamage(AttackDamage);
                FindObjectOfType<AudioManager>().Play("enemyHit");
            }

            if (enemy.tag == "BatEnemy")
            {
                enemy.GetComponentInChildren<Bat_HealthSystem>().TakeDamage(AttackDamage);
                FindObjectOfType<AudioManager>().Play("enemyHit");
            }
        }
    }

    public void AttemptAttack() //Button Funciton
    {
        if (!playerStillAttackAnim)
        {
            attackInputTimeCounter = Time.time + attacInputTime; // Other inputs Check time
            attackCheck = true;
            comingDashInput = false;
            comingJumpInput = false;
            comingSpawnBoxInput = false;
        }
    }

    private void AttackCheck()
    {
        if (Time.time >= attackInputTimeCounter && attackCheck)
        {
            attackCheck = false;
            if (!comingJumpInput && !comingDashInput && !comingSpawnBoxInput)
                canAttack = true;
            else
                canAttack = false;
        }

        if (canAttack)
        {
            canAttack = false;
            animatiorController.PlayAttackAnim();
        }
    }

}
