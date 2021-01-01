using UnityEngine;

public class PlayerInvisScript : MonoBehaviour
{

    public SpriteRenderer sr;
    public Color myColor;
    public float totalTime;
    private float totalTime_Counter;
    public float visibleTime = 0.25f;
    private float visibleTime_Counter= 0;

    public bool playerIsDead = false;
    [SerializeField] private float deathSpeed;
    [SerializeField] public bool opacitySetted;


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        myColor = sr.color;
    }

    void Update()
    {
        visibleTime_Counter += Time.deltaTime;
        if (!playerIsDead)
        {
            makeItUnvisible();
            totalTime_Counter -= Time.deltaTime;
        }
        else if (myColor.a > 0 && playerIsDead)
        {
            if (!opacitySetted)
            {
                myColor.a = 1;
                opacitySetted = true;
            }
            myColor.a -= deathSpeed * Time.deltaTime;
            sr.color = myColor;
        }
    }

    public void setDamageTaken() //Using from healthSystem
    {
        totalTime_Counter = totalTime;
    }

    private void makeItUnvisible()
    {
        if (totalTime_Counter > 0)
        {
            myColor.a = 0;
            sr.color = myColor;

            if (visibleTime_Counter >= visibleTime)
            {
                visibleTime_Counter = 0;
                makeItVisible();
            }
        }
        else
        {
            myColor.a = 255;
            sr.color = myColor;
        }
    }

    private void makeItVisible()
    {
        myColor.a = 255;
        sr.color = myColor;

        if (visibleTime_Counter >= visibleTime + .3f + Time.deltaTime)
        {
            visibleTime_Counter = 0;
            makeItUnvisible();
        }
    }


}
