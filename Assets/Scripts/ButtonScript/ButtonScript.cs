using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    private Animator anim;
    public float waitTime;
    private float waitTime_Counter;
    private bool starCounter;
    [HideInInspector] public bool isPressed;

    private void Start()
    {
        anim = GetComponent<Animator>();
        waitTime_Counter = waitTime;
    }

    private void LateUpdate()
    {
        if (starCounter)
        {
            waitTime_Counter -= Time.deltaTime;
            if (waitTime_Counter <= 0)
            {
                anim.SetBool("Press", false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "Box")
        {
            anim.SetBool("Press", true);
            waitTime_Counter = waitTime;
            starCounter = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "Box")
        {
            anim.SetBool("Press", true);
            waitTime_Counter = waitTime;
            starCounter = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "Box")
            starCounter = true;
    }

    public void setButtonPressedTrue()
    {
        isPressed = true;
    }

    public void setButtonPressedFalse()
    {
        isPressed = false;
    }
}
