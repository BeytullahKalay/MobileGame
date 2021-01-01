using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatTriggerAreaScript : MonoBehaviour
{
    [HideInInspector] public bool enemyInRange;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            enemyInRange = true;
    }
}
