using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Flip : MonoBehaviour
{
    private bool facingRight = false;
    private Vector2 direction;

    void Update()
    {
        if (direction.x > 0 && facingRight == false)
            Flip();
        else if (direction.x < 0 && facingRight == true)
            Flip();
    }

    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
        facingRight = !facingRight;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            direction = transform.position - collision.transform.position;

            if (direction.x > 0)
                direction.x = 1;
            else
                direction.x = -1;
        }
    }
}
