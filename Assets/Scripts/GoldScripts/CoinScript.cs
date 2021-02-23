using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GoldCounter counterScript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && this.gameObject.tag == "Coin")
        {
            counterScript.increaseTheScore(1);
            FindObjectOfType<AudioManager>().Play("Coin");
            gameObject.SetActive(false);
        }
        else if (collision.CompareTag("Player") && this.gameObject.tag == "Ruby")
        {
            counterScript.increaseTheScore(10);
            FindObjectOfType<AudioManager>().Play("Coin");
            gameObject.SetActive(false);
        }
    }
}
