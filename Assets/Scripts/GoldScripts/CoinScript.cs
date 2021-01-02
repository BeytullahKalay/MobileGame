using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GoldCounter counterScript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            counterScript.increaseTheScore();
            FindObjectOfType<AudioManager>().Play("Coin");
            Destroy(gameObject);
        }
    }
}
