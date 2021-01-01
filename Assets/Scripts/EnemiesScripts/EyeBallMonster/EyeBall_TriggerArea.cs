using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBall_TriggerArea : MonoBehaviour
{
    [HideInInspector] public bool inTriggerArea;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inTriggerArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player no in trigger area");
            inTriggerArea = false;
        }
    }
}
