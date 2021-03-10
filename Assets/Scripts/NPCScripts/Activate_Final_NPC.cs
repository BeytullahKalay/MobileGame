using UnityEngine;

public class Activate_Final_NPC : MonoBehaviour
{
    [SerializeField] GameObject _finalNPC;
    private void Update()
    {
        if (PlayerPrefs.GetInt("DashAbilityOpen") == 1)
        {
            _finalNPC.SetActive(true);
        }
        else
        {
            _finalNPC.SetActive(false);
        }
    }
}
