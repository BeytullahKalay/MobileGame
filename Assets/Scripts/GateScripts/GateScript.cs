using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    private Animator anim;
    public GameObject ButtonObject;
    private ButtonScript button;
    public bool reverseButtonCommand;
    private bool gateInput;

    private void Start()
    {
        anim = GetComponent<Animator>();
        button = ButtonObject.GetComponent<ButtonScript>();
    }


    private void LateUpdate()
    {
        if (reverseButtonCommand)
            gateInput = !button.isPressed;
        else
            gateInput = button.isPressed;

        if (gateInput)
            anim.SetBool("ButtonPressed", true);
        else
            anim.SetBool("ButtonPressed", false);

    }
}
