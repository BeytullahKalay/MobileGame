using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GoldCounter counterScript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameObject.tag == "Coin" && collision.gameObject.layer !=10) // Layer 10 = Dead layer
        {
            counterScript.increaseTheScore(1);
            FindObjectOfType<AudioManager>().Play("Coin");
            gameObject.SetActive(false);
        }
        else if (collision.CompareTag("Player") && gameObject.tag == "Ruby" && collision.gameObject.layer != 10)
        {
            counterScript.increaseTheScore(10);
            FindObjectOfType<AudioManager>().Play("Coin");
            gameObject.SetActive(false);
        }
    }
}
