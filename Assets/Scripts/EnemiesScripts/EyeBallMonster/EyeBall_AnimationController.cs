using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBall_AnimationController : MonoBehaviour
{
    private Animator anim;
    private EyeBallMonster_Patroll patrolScript;
    private EyeBall_HealthSystem healthScript;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
        patrolScript = GetComponentInParent<EyeBallMonster_Patroll>();
        healthScript = GetComponent<EyeBall_HealthSystem>();
    }

    private void Update()
    {
        if (patrolScript.rollTime_Counter > 0)
            anim.SetBool("StartRolling", true);
        else
            anim.SetBool("StartRolling", false);

        if (patrolScript.rollTime_Counter <= 0)
            anim.SetBool("StopRolling", true);
        else
            anim.SetBool("StopRolling", false);

        //Death Anim
        if (healthScript.enemyisDead)
            anim.SetBool("isDead",true);
        else
            anim.SetBool("isDead", false);

    }


    //This is Hurt Anim
    public void SetHurtTrigger()
    {
        anim.SetTrigger("Hurt");
    }
}
