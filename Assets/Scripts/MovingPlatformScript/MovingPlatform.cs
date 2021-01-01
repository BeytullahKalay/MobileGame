using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed;
    private int currentPatrolPoint;

    private void Start()
    {
        transform.position = patrolPoints[0].position;
    }

    void Update()
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
            collision.transform.parent = this.gameObject.transform;

        if (collision.collider.tag == "Box")
            collision.transform.parent = GameObject.Find("BoxContainer").transform;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
            collision.transform.parent = this.gameObject.transform;

        if (collision.collider.tag == "Box")
            collision.transform.parent = this.gameObject.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
            collision.transform.parent = null;

        if (collision.collider.tag == "Box")
            collision.transform.parent = null;
    }

    private void OnDrawGizmos()
    {
        if (currentPatrolPoint + 1 < patrolPoints.Length)
            Gizmos.DrawLine(patrolPoints[currentPatrolPoint].position, patrolPoints[currentPatrolPoint + 1].position);
        else
            Gizmos.DrawLine(patrolPoints[currentPatrolPoint].position, patrolPoints[0].position);
    }
}
