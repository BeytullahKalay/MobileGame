using UnityEngine;

public class HurtForceVariables : MonoBehaviour
{
    public float hurtForceTime = 1f; // hurt force how many time effect to player
    public float hurtForceX = 10f;
    public float hurtForceY = 10f;
    [HideInInspector] public bool inHurtForce = false;
    public int touchDamage = 10;
    public float cantControlTime;
    private float cantControlTime_Counter;

    private void Start()
    {
        cantControlTime_Counter = cantControlTime;
    }


    private void Update()
    {
        CheckInHurtForce();
    }


    private void CheckInHurtForce()
    {
        if (inHurtForce)
        {
            cantControlTime_Counter -= Time.deltaTime;
        }

        if (cantControlTime_Counter <= 0)
        {
            inHurtForce = false;
            cantControlTime_Counter = cantControlTime;
        }
    }
}