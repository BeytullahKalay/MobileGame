using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTutorialInfo : MonoBehaviour
{
    public string _playerPrefName;
    public GameObject _infoSceneCam;
    public GameObject _infoGameObject;
    public GameObject _checkPoint;
    public Transform _playerTransform;
    private bool _infoShowed;

    private void Update()
    {
        if (_infoGameObject != null)
        {
            if (PlayerPrefs.GetFloat("PosX") == _checkPoint.transform.position.x)
            {
                PlayerPrefs.SetInt(_playerPrefName, 1);
                _infoGameObject.SetActive(true);
                _infoShowed = true;
            }
            if (PlayerPrefs.GetInt(_playerPrefName) == 1 && !_infoSceneCam.GetComponent<CamTransitionScript>().activeScene && _infoShowed)
            {
                Destroy(_infoGameObject);
                Debug.Log("destroyed");
            }
        }
    }

}
