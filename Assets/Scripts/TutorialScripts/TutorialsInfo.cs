using UnityEngine;

public class TutorialsInfo : MonoBehaviour
{
    public GameObject _infoSceneCam;
    public string _playerPrefName;
    public GameObject _infoGameObject;
    public GameObject _showObject;
    private bool _infoShowed;
    private void Update()
    {
        if (_infoGameObject != null)
        {
            if (_infoSceneCam.GetComponent<CamTransitionScript>().activeScene && _showObject.activeInHierarchy)
            {
                PlayerPrefs.SetInt(_playerPrefName, 1);
                _infoGameObject.SetActive(true);
                _infoShowed = true;
            }
            if (PlayerPrefs.GetInt(_playerPrefName) == 1 && !_infoSceneCam.GetComponent<CamTransitionScript>().activeScene && _infoShowed)
                Destroy(_infoGameObject);
        }
    }
}
