using UnityEngine;

public class GreenSlimePatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed;

    private int currentPatrolPoint;

    private void Start()
    {
        transform.position = patrolPoints[0].position;
    }

    private void Update()
    {

        if (!GetComponentInChildren<EnemySlimeHealthSystem>().enemyisDead)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPatrolPoint].position, speed * Time.deltaTime);

            if (transform.position == patrolPoints[currentPatrolPoint].position)
            {
                transform.rotation = patrolPoints[currentPatrolPoint].rotation;

                if (currentPatrolPoint + 1 < patrolPoints.Length)
                    currentPatrolPoint++;
                else
                    currentPatrolPoint = 0;
            }
        }

        if (GetComponentInChildren<EnemySlimeHealthSystem>().enemyisDead)
        {
            GameObject.Find("GreenSlimeCollider").layer = LayerMask.NameToLayer("Died");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(patrolPoints[currentPatrolPoint].position, 1);
    }
}
