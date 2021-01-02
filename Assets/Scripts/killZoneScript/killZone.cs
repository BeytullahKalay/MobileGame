using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "killZone")
        {
            GetComponentInParent<healthSystem>().TakeDamage(10);
            FindObjectOfType<AudioManager>().Play("Hurt");
        }
    }
}
