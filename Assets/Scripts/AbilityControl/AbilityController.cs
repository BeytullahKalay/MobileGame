using UnityEngine;

public class AbilityController : MonoBehaviour
{
    [Header ("Dialogue Box")]
    public GameObject _openBoxAbilityDialogue;

    private void Start()
    {

    }

    void Update()
    {
        if (_openBoxAbilityDialogue.active)
        {
            PlayerPrefs.SetInt("BoxAbilityOpen", 1);
            Debug.Log("Activated");
        }
    }
}
