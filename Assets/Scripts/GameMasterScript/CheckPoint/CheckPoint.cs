using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameMaster gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gm.lastCheckPointPos = transform.position;

            PlayerPrefs.SetFloat("PosX", transform.position.x);
            PlayerPrefs.SetFloat("PosY", transform.position.y);
        }
    }
}
