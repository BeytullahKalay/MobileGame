using UnityEngine;

public class NPC_InfoText : MonoBehaviour
{
    public GameObject NPC_GameObject;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            NPC_GameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            NPC_GameObject.SetActive(false);
    }
}
