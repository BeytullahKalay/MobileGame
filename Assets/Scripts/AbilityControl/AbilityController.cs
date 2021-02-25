using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public GameObject _openBoxAbilityDialogue;

    private GameMaster _gm;

    private void Start()
    {
        _gm = FindObjectOfType<GameMaster>();
    }

    void Update()
    {
        if (_openBoxAbilityDialogue.active)
        {
            PlayerPrefs.SetInt("BoxAbilityOpen", 1);
            Debug.Log("Activated");
        }

        _gm.GetComponent<AbilityHolder>()._canSpawnBox = PlayerPrefs.GetInt("BoxAbilityOpen");
    }
}
