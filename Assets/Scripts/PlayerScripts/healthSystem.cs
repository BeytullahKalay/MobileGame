using UnityEngine;

public class healthSystem : MonoBehaviour
{
    [HideInInspector]public int currentHealt;
    public int maxHealt = 100;
    public float timeAfterTouchHurtStart;
    private float timeAfterTouchHurtCounter;
    [HideInInspector] public bool isDead;
    [HideInInspector] public bool touchedToEnemy;

    private void Start()
    {
        currentHealt = maxHealt;
    }

    private void Update()
    {
        if (touchedToEnemy)
        {
            timeAfterTouchHurtCounter -= Time.deltaTime;

            if (timeAfterTouchHurtCounter <= 0)
            {
                touchedToEnemy = false;
                timeAfterTouchHurtCounter = timeAfterTouchHurtStart;
            }
        }

        ifStillCantDamageToPlayer();
    }

    public void TakeDamage(int damage)
    {

        currentHealt -= damage;

        //Playin Hurt anim
        GetComponentInChildren<PlayerInvisScript>().setDamageTaken();

        if (currentHealt <= 0)
        {
            //Play Death anim
            isDead = true;
            GetComponentInChildren<PlayerInvisScript>().playerIsDead = true;
            GetComponent<Movement>().enabled = false;

            GameObject.Find("PlayerCollider").layer = 10;   // Died Layer
        }
        else
        {
            GetComponentInChildren<PlayerInvisScript>().playerIsDead = false;
            isDead = false;
        }
    }

    private void ifStillCantDamageToPlayer()
    {
        if (timeAfterTouchHurtCounter > 0 && touchedToEnemy)
        {
            GameObject.Find("PlayerCollider").layer = 14;   // Hurted Layer
        }
        else
            GameObject.Find("PlayerCollider").layer = 11;   // Player Layer
    }
}
