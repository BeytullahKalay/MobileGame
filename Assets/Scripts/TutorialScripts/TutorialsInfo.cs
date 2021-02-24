using UnityEngine;

public class TutorialsInfo : MonoBehaviour
{
    public GameObject _infoSceneCam;
    private bool _infoShowed;

    private void Update()
    {
        if (_infoSceneCam.GetComponent<CamTransitionScript>().activeScene)
            PlayerPrefs.SetInt("info", 1);

        if (PlayerPrefs.GetInt("info") == 1 && !_infoSceneCam.GetComponent<CamTransitionScript>().activeScene)
            Destroy(gameObject);
        
    }
}
