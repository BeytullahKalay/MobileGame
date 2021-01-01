using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;
    [SerializeField] private float respawnTime = 1.5f;
    private float respawnTime_Counter;
    private bool playerSpawned;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
        respawnTime_Counter = 0;
    }

    private void Update()
    {
        if (GetComponent<healthSystem>().isDead)
        {
            playerSpawned = false;
            if (!playerSpawned)
            {
                respawnTime_Counter += Time.deltaTime;

                if (respawnTime_Counter >= respawnTime)
                    Revive();
            }
        }
    }


    private void Revive()
    {
        playerSpawned = true;
        respawnTime_Counter = 0;

        transform.position = gm.lastCheckPointPos;

        GetComponent<healthSystem>().currentHealt = GetComponent<healthSystem>().maxHealt;
        GetComponentInChildren<PlayerInvisScript>().myColor.a = 255;
        GetComponentInChildren<PlayerInvisScript>().sr.color = GetComponentInChildren<PlayerInvisScript>().myColor;
        GetComponentInChildren<PlayerInvisScript>().playerIsDead = false;
        GetComponentInChildren<PlayerInvisScript>().opacitySetted = false;

        GetComponent<healthSystem>().isDead = false;

        GetComponent<Movement>().enabled = true;

        GameObject.Find("PlayerCollider").layer = 11;   // Player Layer
    }
}
