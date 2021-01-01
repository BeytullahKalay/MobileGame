using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerAreaScript : MonoBehaviour
{
    [HideInInspector]public bool inRange;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
