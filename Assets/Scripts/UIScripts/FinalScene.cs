using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScene : MonoBehaviour
{
    public GameObject finalSceneUI;
    public GameObject box;

    private void Update()
    {

        if (box.GetComponent<EndGame>().touch)
        {
            ActivateToPanel();
            GameObject.Find("Player").GetComponent<Movement>().enabled = false;
        }
    }

    public void GotIt()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ActivateToPanel()
    {
        finalSceneUI.SetActive(true);
    }
}
