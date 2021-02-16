using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialsInfo : MonoBehaviour
{
    public GameObject _infoSceneCam;
    private bool _infoShowed;

    private void Update()
    {
        if (_infoSceneCam.GetComponent<CamTransitionScript>().activeScene)
            _infoShowed = true;

        if (!_infoSceneCam.GetComponent<CamTransitionScript>().activeScene && _infoShowed)
            this.gameObject.SetActive(false);


    }
}
