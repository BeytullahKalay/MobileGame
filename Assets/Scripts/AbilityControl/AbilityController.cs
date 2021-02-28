using UnityEngine;

public class AbilityController : MonoBehaviour
{
    [Header ("Open Box Ability Dialogue")]
    public GameObject _openBoxAbilityDialogue;
    public GameObject _openDashAbilityDialogue;

    void Update()
    {
        if (_openBoxAbilityDialogue.active)
            PlayerPrefs.SetInt("BoxAbilityOpen", 1);

        if (_openDashAbilityDialogue.active)
            PlayerPrefs.SetInt("DashAbilityOpen",1);
    }
}
