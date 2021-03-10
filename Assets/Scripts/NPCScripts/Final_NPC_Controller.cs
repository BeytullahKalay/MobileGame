using UnityEngine;

public class Final_NPC_Controller : MonoBehaviour
{
    [SerializeField] private GameObject finalDialogue;

    public void ActivateDialogue()
    {
        finalDialogue.SetActive(true);
    }

    public bool dialogueActive()
    {
        return finalDialogue.activeInHierarchy;
    }
}
