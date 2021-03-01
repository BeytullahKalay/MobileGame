using System.Collections.Generic;
using UnityEngine;

public class GoldAndCheckPoints : MonoBehaviour
{
    public GoldCounter counterScript;
    private List<GameObject> Coins;
    private List<GameObject> Rubies;
    [HideInInspector] public bool canDestroy;
    private bool decreased;

    private void Start()
    {
        Coins = new List<GameObject>();
        Rubies = new List<GameObject>();
    }

    private void Update()
    {
        if (GetComponentInParent<healthSystem>().isDead && !decreased) // if player died
        {
            decreased = true;
            while (Coins.Count > 0)
            {
                Coins[0].gameObject.SetActive(true);
                counterScript.decreaseTheScore(1);
                Coins.Remove(Coins[0]);
            }

            while (Rubies.Count > 0)
            {
                Rubies[0].gameObject.SetActive(true);
                counterScript.decreaseTheScore(10);
                Rubies.Remove(Rubies[0]);
            }
        }

        if (!GetComponentInParent<healthSystem>().isDead)
            decreased = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Coins.Add(collision.gameObject);
        }

        if (collision.CompareTag("Ruby"))
        {
            Rubies.Add(collision.gameObject);
        }

        if (collision.gameObject.layer == 16) //Check Point Layer
        {
            while (Coins.Count > 0)
            {
                Destroy(Coins[0]);
                Coins.Remove(Coins[0]);
                Resources.UnloadUnusedAssets();
            }

            while (Rubies.Count > 0)
            {
                Destroy(Rubies[0]);
                Rubies.Remove(Rubies[0]);
                Resources.UnloadUnusedAssets();
            }
        }
    }
}
