using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GoldCounter counterScript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameObject.tag == "Coin" && collision.gameObject.layer !=14) // Layer 14 = Hurted layer
        {
            counterScript.increaseTheScore(1);
            FindObjectOfType<AudioManager>().Play("Coin");
            gameObject.SetActive(false);
        }
        else if (collision.CompareTag("Player") && gameObject.tag == "Ruby" && collision.gameObject.layer != 14)
        {
            counterScript.increaseTheScore(10);
            FindObjectOfType<AudioManager>().Play("Coin");
            gameObject.SetActive(false);
        }
    }
}
