using UnityEngine;



public class DisableSwipes : MonoBehaviour
{
    private bool canDisable;
    private Color color;
    public GameObject[] swipes;

    private void Start()
    {
        color = swipes[0].GetComponent<SpriteRenderer>().color;
    }

    private void Update()
    {
        if (canDisable)
        {
            color.a -= Time.deltaTime;
        }

        foreach (GameObject gameObject in swipes)
        {
            gameObject.GetComponent<SpriteRenderer>().color = color;
        }

        if (color.a < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Triggered");
            canDisable = true;
        }
    }
}
