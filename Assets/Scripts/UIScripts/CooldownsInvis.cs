using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownsInvis : MonoBehaviour
{
    public GameObject _dashObject_UI;
    public GameObject _boxObject_UI;


    private void Update()
    {
        if (PlayerPrefs.GetInt("BoxAbilityOpen") == 1)
            _boxObject_UI.SetActive(true);
        else
            _boxObject_UI.SetActive(false);
    }
}
