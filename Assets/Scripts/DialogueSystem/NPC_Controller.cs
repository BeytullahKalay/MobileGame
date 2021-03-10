using UnityEngine;

public class NPC_Controller : MonoBehaviour
{
    [SerializeField] private GameObject dialogue1;
    [SerializeField] private GameObject dialogue2;
    [SerializeField] private GameObject dialogue3;
    [SerializeField] private GameObject goalObject;

    public void ActivateDialogue()
    {
        if (PlayerPrefs.GetFloat("PosX") == 106.27f) //Last Check pos
        {
            dialogue3.SetActive(true);
        }
        //else if (PlayerPrefs.GetFloat("PosX") == -52.47 || PlayerPrefs.GetFloat("PosX") == -21)
        //{

        //}
        else
        {
            if (goalObject != null && goalObject.activeInHierarchy) //if player not have goal object
            {
                dialogue1.SetActive(true);
            }
            else
            {
                dialogue2.SetActive(true);
            }
        }
    }

    public bool dialogueActive()
    {
        return dialogue1.activeInHierarchy ||dialogue2.activeInHierarchy || dialogue3.activeInHierarchy;
    }
}
