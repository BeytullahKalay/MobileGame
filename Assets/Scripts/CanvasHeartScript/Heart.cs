using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public int numberOfHearts;
    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite brokenHearts;

    public GameObject playerGameObject;

    private void Start()
    {
        if (playerGameObject.GetComponent<healthSystem>().maxHealt < numberOfHearts)
        {
            for (int i = 0; i < numberOfHearts; i++)
            {
                if (i > playerGameObject.GetComponent<healthSystem>().maxHealt - 1)
                {
                    hearts[i].gameObject.SetActive(false);
                }
            }
        }
    }

    private void Update()
    {
        if (playerGameObject.GetComponent<healthSystem>().maxHealt > numberOfHearts)
        {
            playerGameObject.GetComponent<healthSystem>().maxHealt = numberOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < numberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

            if (i < playerGameObject.GetComponent<healthSystem>().currentHealt)
            {
                hearts[i].sprite = fullHearts;
            }
            else
            {
                hearts[i].sprite = brokenHearts;
            }
        }
    }

}
