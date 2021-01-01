using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPatrol : MonoBehaviour
{
    private triggerAreaScript triggerScript;
    private EnemyRobotHealthSystem healthSystem;

    public Transform[] patrolPoints;

    private Vector2 targetPosition;

    private float currentWaitTime;

    public float speed;
    public float waitTimeOnPatrolPoint;
    public float AttackRate = 2f;
    public float attackRange;

    public int AttackDamage;


    [HideInInspector] public bool canAttack;
    [HideInInspector] public bool canRun;

    private int currentPatrolPoint;

    private void Start()
    {
        triggerScript = GetComponentInChildren<triggerAreaScript>();
        healthSystem = GetComponentInChildren<EnemyRobotHealthSystem>();

        targetPosition = new Vector2(patrolPoints[0].position.x, patrolPoints[0].position.y); //First Position of Enemy
        transform.position = patrolPoints[0].position;

        currentWaitTime = waitTimeOnPatrolPoint;
    }


    private void Update()
    {
        if (!healthSystem.enemyisDead)
        {
            if (!triggerScript.inRange)
            {
                canAttack = false;

                // move next position
                targetPosition = new Vector2(patrolPoints[currentPatrolPoint].position.x, transform.position.y);

                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

                SelectNextPosition();

            }
            else if (triggerScript.inRange)
            {
                //Play an attack anim
                canAttack = true;
                canRun = false;
            }
        }
    }

    private void SelectNextPosition()
    {
        if (transform.position.x == patrolPoints[currentPatrolPoint].position.x)
        {
            canRun = false;

            PatrolCoroutin();
        }
    }


    private void PatrolCoroutin()
    {
        if (currentWaitTime <= 0) // Time for waiting on patrol points
        {
            if (currentPatrolPoint + 1 < patrolPoints.Length)
                currentPatrolPoint++;
            else
                currentPatrolPoint = 0;

            currentWaitTime = waitTimeOnPatrolPoint;

            #region Enemy Facing
            if (currentPatrolPoint == 0)
            {
                transform.rotation = patrolPoints[1].rotation;
            }
            else
            {
                transform.rotation = patrolPoints[currentPatrolPoint - 1].rotation;
            }
            #endregion

            canRun = true;
        }
        else
            currentWaitTime -= Time.deltaTime;
    }

}
