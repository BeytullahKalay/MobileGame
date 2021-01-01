using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnimatorController : MonoBehaviour
{
    private Animator anim;
    private EnemySlimeHealthSystem enemyHealtScript;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
        enemyHealtScript = GetComponent<EnemySlimeHealthSystem>();
    }


    private void Update()
    {
        if (enemyHealtScript.enemyisDead) // if enemy died
            anim.SetBool("Death", true);
    }

    public void setHurtTrigger() // using for EnemySlimeHealthSystem Script
    {
        anim.SetTrigger("Hurt");
    }
}
