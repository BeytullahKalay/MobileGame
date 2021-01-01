using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_HealthSystem : MonoBehaviour
{
    public int maxHealth = 1;
    private int currenHealth;
    [HideInInspector] public bool isDead = false;

    private void Start()
    {
        currenHealth = maxHealth;
    }

    private void Update()
    {
        if (isDead)
            GameObject.Find("BatCollider").layer = 10; //Died Layer
    }
    public void TakeDamage(int damage)
    {
        currenHealth -= damage;
        if (currenHealth <= 0)
        {
            isDead = true;
            GetComponentInParent<Animator>().SetTrigger("isDead");
        }
    }
}
