using UnityEngine;

public class AbilityController : MonoBehaviour
{
    [Header ("Open Box Ability Dialogue")]
    public GameObject _openBoxAbilityDialogue;
    public GameObject _openDashAbilityDialogue;
    public GameObject _openAttackAbilityCutScene;

    void Update()
    {
        if (_openBoxAbilityDialogue.activeInHierarchy)
            PlayerPrefs.SetInt("BoxAbilityOpen", 1);

        if (_openDashAbilityDialogue.activeInHierarchy)
            PlayerPrefs.SetInt("DashAbilityOpen",1);
    }
}
