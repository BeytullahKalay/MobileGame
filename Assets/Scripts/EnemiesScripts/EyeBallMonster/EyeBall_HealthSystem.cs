using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBall_HealthSystem : MonoBehaviour
{
    public int maxHealt = 100;
    private int currentHealt;
    [HideInInspector] public bool enemyisDead;

    private void Start()
    {
        currentHealt = maxHealt;
    }

    public void TakeDamage(int damage)
    {
        currentHealt -= damage;
        GetComponent<EyeBall_AnimationController>().SetHurtTrigger();

        if (currentHealt <= 0)
        {
            enemyisDead = true;
            this.gameObject.layer = 10; //Died Layer
        }

    }
}
