using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRobotHealthSystem : MonoBehaviour
{
    private int currentHealth;
    public int maxHealth = 100;

    [HideInInspector] public bool enemyisDead;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        GetComponent<RobotEnemyAnimatorController>().setHurtTrigger();

        if (currentHealth <= 0)
        {
            enemyisDead = true;
            this.gameObject.layer = 10; //Died layer
        }

    }

}
