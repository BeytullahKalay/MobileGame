using UnityEngine;

public class CutScene2ColliderScript : MonoBehaviour
{
    [SerializeField] private GameObject _dialogue;
    [SerializeField] bool _activated;

    private void Start()
    {
        if (PlayerPrefs.GetInt("CutScene2Collider") == 1)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (_dialogue.activeInHierarchy)
        {
            _activated = true;
            PlayerPrefs.SetInt("CutScene2Collider",1);
        }

        if (_activated)
        {
            Destroy(gameObject);
        }
    }
}
